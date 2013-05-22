// GMusicHooks.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "GMusicHooks.h"


#pragma comment(linker, "/section:HOOKDAT,RWS") 
#pragma data_seg( "HOOKDAT" )
HWND gWindow = NULL; // !! must be initialized !!
bool gHandleBrowserCommands = false;
#pragma data_seg()

HINSTANCE gModule;
HHOOK gHookProc = NULL;


BOOL APIENTRY DllMain( HMODULE hModule,
                      DWORD  ul_reason_for_call,
                      LPVOID lpReserved
                      )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        gModule = hModule;
        break;
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

LRESULT CALLBACK ShellProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	            /*
#define APPCOMMAND_BROWSER_BACKWARD       1
#define APPCOMMAND_BROWSER_FORWARD        2
#define APPCOMMAND_BROWSER_REFRESH        3
#define APPCOMMAND_BROWSER_STOP           4
#define APPCOMMAND_MEDIA_NEXTTRACK        11
#define APPCOMMAND_MEDIA_PREVIOUSTRACK    12
#define APPCOMMAND_MEDIA_STOP             13
#define APPCOMMAND_MEDIA_PLAY_PAUSE       14
#define APPCOMMAND_LAUNCH_MEDIA_SELECT    16
             */
    if (HSHELL_APPCOMMAND == nCode )
    {
        switch( GET_APPCOMMAND_LPARAM(lParam) )
        {
			case APPCOMMAND_MEDIA_NEXTTRACK:
			case APPCOMMAND_MEDIA_PREVIOUSTRACK:
			case APPCOMMAND_MEDIA_STOP:
			case APPCOMMAND_MEDIA_PLAY_PAUSE:
			case APPCOMMAND_LAUNCH_MEDIA_SELECT:
				SendMessage(gWindow, WM_APPCOMMAND, wParam, lParam);
				return 1;
			case APPCOMMAND_BROWSER_BACKWARD:
			case APPCOMMAND_BROWSER_FORWARD:
			case APPCOMMAND_BROWSER_REFRESH:
			case APPCOMMAND_BROWSER_STOP:
			case APPCOMMAND_BROWSER_HOME:
				if (gHandleBrowserCommands) {
					SendMessage(gWindow, WM_APPCOMMAND, wParam, lParam);
					return 1;
				}
				break;
			default:
#if _DEBUG
				SendMessage(gWindow, WM_APPCOMMAND, wParam, lParam); //for debugging
#endif
				break;
        }
    }
    return CallNextHookEx (gHookProc, nCode, wParam, lParam);
}

DWORD CALLBACK RegisterMediaHooks( HWND _inHwnd, bool _handleBrowserCommands )
{
	gHandleBrowserCommands = _handleBrowserCommands;
    DWORD dwErrId = 0;
    gHookProc = SetWindowsHookEx( WH_SHELL, ShellProc, gModule, 0 );
    if( NULL == gHookProc )
    {
        dwErrId = GetLastError( );
    }
    else
    {
        gWindow = _inHwnd;
    }
    return dwErrId;
}

DWORD CALLBACK UnregisterMediaHooks()
{
    if( NULL != gHookProc )
    {
        BOOL result = UnhookWindowsHookEx( gHookProc );
        DWORD dwErrId = 0; 
        if( FALSE == result )
        {
            dwErrId = GetLastError( );
        }
        else
        {
            gWindow = NULL;
            gHookProc = NULL;
        }
        return dwErrId;
    }
    return 0;
}
