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
using CSharp.src.features;
using CSharp.src.sdk;
using Memory;

namespace CSharp {
    public partial class MainWindow : Form {

        public MainWindow( ) => InitializeComponent( );
        private static bunnyhop Bhop = new bunnyhop( );
        private static triggerbot Triggerbot = new triggerbot( );
      
        private void Initialize( object sender, EventArgs e ) {

            while ( G.Memory.GetProcIdFromName( "cs2" ) == 0 )
                continue;

            G.Memory.OpenProcess( G.Memory.GetProcIdFromName( "cs2" ) );
            G.Initialize( );

            config.Initialize( Controls );
        }

        private void Features( object sender, EventArgs e ) {

            Bhop.Run( bBunnyHop.Checked );
            Triggerbot.Run( bTrigger.Checked );
        }

        private void SaveConfig( object sender, EventArgs e ) => config.SaveConfig( );
        private void LoadConfig( object sender, EventArgs e ) => config.LoadConfig( );
    }
}
