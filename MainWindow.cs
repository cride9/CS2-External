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
using CSharp.src.sdk;
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
            GetComponents( );
            config.Initialize( Controls );

            Timer.Tick += Features;
            Timer.Start( );
        }

        private void Features( object sender, EventArgs e ) {

            Bhop.Run( bBunnyHop.Checked );
        }

        private void GetComponents( ) {

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

        private void SaveConfig( object sender, EventArgs e ) {

            if ( MessageBox.Show( "Are you sure?", "Saving", MessageBoxButtons.OKCancel ) == DialogResult.OK )
                config.SaveConfig( );
        }

        private void LoadConfig( object sender, EventArgs e ) {

            if ( MessageBox.Show( "Are you sure?", "Loading", MessageBoxButtons.OKCancel ) == DialogResult.OK )
                config.LoadConfig( );
        }
    }

    enum FEATURE {

        BUNNYHOP,
        TRIGGERBOT
    }
}
