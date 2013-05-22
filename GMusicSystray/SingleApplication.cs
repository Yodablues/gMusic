//modified from http://k-kovalev-personal.googlecode.com/svn/trunk/HotKeying/SingleInstanceLib/
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace GMusic
{

    public class ApplicationInstanceEventArgs : EventArgs
    {
        public string Command { get; set; }
        
        public ApplicationInstanceEventArgs(string command) {
            this.Command = command;
        }
    }

    public delegate void ApplicationInstanceEventHandler(object sender, ApplicationInstanceEventArgs e);

    internal static class GlobalEvents
    {
        public static event ApplicationInstanceEventHandler NewApplicationInstanceLoaded;

        public static void RaiseNewApplicationInstanceLoaded(object sender, string command)
        {
            if (NewApplicationInstanceLoaded != null)
                NewApplicationInstanceLoaded(sender, new ApplicationInstanceEventArgs(command));
        }
    }

    [ServiceContract(Namespace = "http://extendev.org/singleinstance")]
    public interface ISingleInstanceContract
    {
        [OperationContract]
        void NotifyApplicationAboutNewInstance(string command);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class SingleInstanceContract : ISingleInstanceContract
    {
        public void NotifyApplicationAboutNewInstance(string command)
        {
            GlobalEvents.RaiseNewApplicationInstanceLoaded(this, command);
        }
    }

    public class SingleInstance : IDisposable
    {
        private readonly ApplicationInstanceManager _instanceManager;
        
        public SingleInstance()
        {
            _instanceManager = new ApplicationInstanceManager();
            _instanceManager.NewApplicationInstanceLoaded += NewApplicationInstanceLoaded;
        }

        void NewApplicationInstanceLoaded(object sender, ApplicationInstanceEventArgs e)
        {
            switch (e.Command)
            {
                case "playpause":
                    Player.Instance.PlayPause();
                    break;
                case "next":
                case "nexttrack":
                    Player.Instance.NextTrack();
                    break;
                case "prev":
                case "previous":
                case "prevtrack":
                case "previoustrack":
                    Player.Instance.PrevTrack();
                    break;
                default:
                    Player.Instance.ShowPlayer();
                    break;
            }
            
        }

        public void Run(string command)
        {
            if (!_instanceManager.IsInstanceAlreadyRunning)
            {
                _instanceManager.RegisterSingleInstance();
                System.Windows.Forms.Application.Run(Player.Instance);
            }
            else
            {
                _instanceManager.NotifyAboutNewInstance(command);
            }
        }

        public void Dispose()
        {
            _instanceManager.NewApplicationInstanceLoaded -= NewApplicationInstanceLoaded;
            _instanceManager.Dispose();
        }
    }

    internal class SingleInstanceClient : ClientBase<ISingleInstanceContract>, ISingleInstanceContract
    {
        public SingleInstanceClient(Binding binding, EndpointAddress endpointAddress)
            : base(binding, endpointAddress)
        {

        }

        public void NotifyApplicationAboutNewInstance(string command)
        {
            Channel.NotifyApplicationAboutNewInstance(command);
        }
    }

    public class ApplicationInstanceManager : IDisposable
    {
        private const string PipeName = "SingleInstance";
        private const string UniqueApplicationName = "FDC90E10-01C4-4E49-A775-0EAD7CF9F5F3";
        
        private readonly bool _isAlreadyRunning;
        private readonly Mutex _mutex;
        private readonly SingleInstanceContract _service;

        private bool _isServiceStarted;
        private ServiceHost _serviceHost;

        public ApplicationInstanceManager()
        {
            bool createdNew;
            _mutex = new Mutex(true, UniqueApplicationName, out createdNew);
            _isAlreadyRunning = !createdNew;
            _service = new SingleInstanceContract();
            GlobalEvents.NewApplicationInstanceLoaded += OnNewApplicationInstanceLoaded;
        }

        /// <summary>
        /// Returns true if one instance of application is already runs
        /// </summary>
        public bool IsInstanceAlreadyRunning
        {
            get { return _isAlreadyRunning; }
        }

        /// <summary>
        /// Start WCF server and wait for connections
        /// </summary>
        public void RegisterSingleInstance()
        {
            if (IsInstanceAlreadyRunning)
                throw new InvalidOperationException("You cannot start register two or more instances. One application instance is already running");

            if (_isServiceStarted)
                return;

            _serviceHost = new ServiceHost(_service, ServerUri);
            _serviceHost.AddServiceEndpoint(typeof(ISingleInstanceContract), new NetNamedPipeBinding(), PipeName);
            _serviceHost.Open();
            _isServiceStarted = true;
        }

        /// <summary>
        /// Starts WCF client and send command to running instance for openning
        /// </summary>
        public void NotifyAboutNewInstance(string command)
        {
            using (SingleInstanceClient client = new SingleInstanceClient(new NetNamedPipeBinding(), new EndpointAddress(ServerUri.OriginalString + "/" + PipeName)))
            {
                client.NotifyApplicationAboutNewInstance(command);
            }
        }

        void OnNewApplicationInstanceLoaded(object sender, ApplicationInstanceEventArgs e)
        {
            if (NewApplicationInstanceLoaded != null)
                NewApplicationInstanceLoaded(this, e);
        }

        public event ApplicationInstanceEventHandler NewApplicationInstanceLoaded;

        private Uri ServerUri
        {
            get { return new Uri(string.Format("net.pipe://localhost/{0}", UniqueApplicationName)); }
        }

        public void Dispose()
        {
            if (_isServiceStarted)
            {
                _serviceHost.Close();
                _isServiceStarted = false;
            }

            if (!_isAlreadyRunning) _mutex.ReleaseMutex();

            GlobalEvents.NewApplicationInstanceLoaded -= OnNewApplicationInstanceLoaded;
        }
    }

}
