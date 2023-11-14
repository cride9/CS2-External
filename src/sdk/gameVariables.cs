using client;
using CSharp.src;
using CSharp.src.classes;
using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp {

    public static class G {

        public static Mem Memory = new Mem( );

        public static long uLocalPlayerController;
        public static Pawn uLocalPlayerPawn;

        public static long uGlobalVars;

        public static long uEntityList;

        public static long uViewMatrix;

        public static void Initialize() {

            FN.GetStaticComponents( );
            FN.GetDynamicComponents( );
        }
    }

    public static class FN {

        [DllImport( "user32.dll" )]
        public static extern short GetAsyncKeyState( Keys vKey );

        public static long GetEntity( long uHandle ) =>
            memory.Read<long>( G.uEntityList + 0x8 * ( ( uHandle & 0x7FFF ) >> 9 ) + 16 );
        public static long GetPawn(long uListEntry, long uHandle) =>
            memory.Read<long>(uListEntry + 120 * (uHandle & 0x1FF ) );

        public static long GetPlayerPawn( long uHandle ) {

            long uListEntry = GetEntity(uHandle);
            if ( uListEntry == 0 )
                return 0;

            return GetPawn( uListEntry, uHandle );
        }

        public static long GetActiveWeapon( long uServices ) {

            long uHandle = memory.Read<long>( uServices + CPlayer_WeaponServices.m_hActiveWeapon );
            long uListEntry = GetEntity(uHandle);
            if ( uListEntry == 0 )
                return 0;

            return GetPawn( uListEntry, uHandle );
        }

        public static void GetStaticComponents( ) {

            /* Main components */
            G.uEntityList = memory.Read<long>( DLL.CLIENT, client_dll.dwEntityList );
            G.uGlobalVars = memory.Read<long>( DLL.CLIENT, client_dll.dwGlobalVars );
            G.uViewMatrix = memory.Read<long>( DLL.CLIENT, client_dll.dwViewMatrix );
        }

        public static void GetDynamicComponents( ) {

            /* Those are changing each game */
            G.uLocalPlayerController = memory.Read<long>( DLL.CLIENT, client_dll.dwLocalPlayerController );
            G.uLocalPlayerPawn = new Pawn( FN.GetPlayerPawn( memory.Read<long>( G.uLocalPlayerController + CCSPlayerController.m_hPlayerPawn ) ) );
        }

        [DllImport( "user32.dll", SetLastError = true )]
        public static extern void mouse_event( int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo );

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
    }
}
