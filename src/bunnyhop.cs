﻿using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.src {
    internal class bunnyhop {

        public bool bStopThread = false;
        public static Thread Thread;

        private static memory forceJump = new memory( $"client.dll+{memory._( client_dll.dwForceJump )}" );

        public bunnyhop() =>
            Thread = new Thread( BunnyHop ) { Priority = ThreadPriority.Highest };

        public void Run(bool bCurrentCheckbox) {

            if ( bCurrentCheckbox && Thread.ThreadState == ThreadState.Suspended )
                Thread.Resume( );
            else if ( Thread.ThreadState == ThreadState.Running && !bCurrentCheckbox )
                Thread.Suspend( );
            else if ( Thread.ThreadState == ThreadState.Unstarted && bCurrentCheckbox )
                Thread.Start( );
        }

        public void BunnyHop( ) {

            while ( true ) {

                Thread.Sleep( 1 );
                if ( FN.GetAsyncKeyState( Keys.Space ) >= 0 )
                    continue;

                int iFlags = G.uLocalPlayerPawn.GetFlags( );
                bool bIsOnGround = iFlags == 65665 || iFlags == 65667;

                if ( bIsOnGround ) {

                    Thread.Sleep( 1 );
                    forceJump.Write<int>( 65536 );
                    Thread.Sleep( 20 );
                    forceJump.Write<int>( 256 );
                }
                else {

                    forceJump.Write<int>( 256 );
                }
            }
        }
    }
}
