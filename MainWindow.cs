using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client;
using CSharp.src;
using CSharp.src.classes;
using Memory;

namespace CSharp {
    public partial class MainWindow : Form {

        public MainWindow( ) => InitializeComponent( );
        private static Mem Memory = G.GetMemory( );
        private static Timer Timer = new Timer( ) { Interval = 1 };

        private static bunnyhop Bhop = new bunnyhop( );
        private void Initialize( object sender, EventArgs e ) {

            int iPid = Memory.GetProcIdFromName( "cs2" );

            while ( iPid == 0 ) 
                iPid = Memory.GetProcIdFromName( "cs2" );

            Memory.OpenProcess( iPid );
            ThreadScheduler( );

            Timer.Tick += Features;
            Timer.Start( );
        }

        private void Features( object sender, EventArgs e ) {

            Bhop.Run( checkBox1.Checked );
            label1.Text = $"{ memory.Read<long>( DLL.CLIENT, client_dll.dwForceJump ) }";
            label2.Text = $"{ ( memory.Read<long>( G.uLocalPlayerPawn.uBase, C_BaseEntity.m_fFlags )) }";
        }

        private void ThreadScheduler( ) {

            GetStaticComponents( );
            GetDynamicComponents( );
        }

        private void GetStaticComponents( ) {

            /* Main components */
            G.uEntityList = memory.Read<long>( DLL.CLIENT, client_dll.dwEntityList );
            G.uGlobalVars = memory.Read<long>( DLL.CLIENT, client_dll.dwGlobalVars );
            G.uViewMatrix = memory.Read<long>( DLL.CLIENT, client_dll.dwViewMatrix );
        }

        private void GetDynamicComponents() {

            /* Those are changing each game */
            G.uLocalPlayerController = memory.Read<long>( DLL.CLIENT, client_dll.dwLocalPlayerController );
            G.uLocalPlayerPawn = new Pawn(FN.GetPlayerPawn( memory.Read<long>( G.uLocalPlayerController + CCSPlayerController.m_hPlayerPawn ) ) );
        }
    }

    enum FEATURE {

        BUNNYHOP,
        TRIGGERBOT
    }
}
