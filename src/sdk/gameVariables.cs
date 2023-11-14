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

        public static Mem GetMemory( ) => Memory;
    }

    public static class FN {

        [DllImport( "user32.dll" )]
        public static extern short GetAsyncKeyState( Keys vKey );

        public static long GetPlayerPawn( long uHandle ) {

            long uListEntry = memory.Read<long>( G.uEntityList + 0x8 * ( ( ( uHandle ) & 0x7FFF ) >> 9 ) + 16 );
            if ( uListEntry == 0 )
                return 0;

            long uPlayerPawn = memory.Read<long>( uListEntry + 120 * ( uHandle & 0x1FF ) );

            return uPlayerPawn;
        }
    }
}
