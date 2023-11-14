using client;
using CSharp.src.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.src.features {

    internal class triggerbot {

        public bool bStopThread = false;
        public static Thread Thread;

        public triggerbot( ) => Thread = new Thread( TriggerBot ) { Priority = ThreadPriority.Highest };

        public void Run( bool bCurrentCheckbox ) {

            if ( bCurrentCheckbox && Thread.ThreadState == ThreadState.Suspended )
                Thread.Resume( );
            else if ( Thread.ThreadState == ThreadState.Running && !bCurrentCheckbox )
                Thread.Suspend( );
            else if ( Thread.ThreadState == ThreadState.Unstarted && bCurrentCheckbox )
                Thread.Start( );
        }

        public void TriggerBot( ) {

            while ( true ) {

                Thread.Sleep( 1 );
                if ( FN.GetAsyncKeyState( Keys.XButton1 ) >= 0 || !G.uLocalPlayerPawn.IsValid( ) )
                    continue;

                long uWeaponServices = memory.Read<long>( G.uLocalPlayerPawn + C_BasePlayerPawn.m_pWeaponServices );
                if ( uWeaponServices < 0 )
                    continue;

                Weapon uActiveWeapon = new Weapon( FN.GetActiveWeapon( uWeaponServices ) );
                if ( !uActiveWeapon.IsValid() )
                    return;
                
                FN.mouse_event( FN.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0 );
                Thread.Sleep( 50 );
                FN.mouse_event( FN.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0 );
            }
        }
    }
}
