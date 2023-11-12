using client;
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

    public enum DLL {

        CLIENT,
        ENGINE
    }

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

        private static string[ ] Modules = new string[ ] { "client.dll", "engine2.dll" };
        public static string _( int number ) => ( ( $"0x{number:X}" ));
        public static string _( long number ) => ( ( $"0x{number:X}" ) );

        public static long GetPlayerPawn( long uHandle ) {

            long uListEntry = ReadMemory( G.uEntityList + 0x8 * ( ( ( uHandle ) & 0x7FFF ) >> 9 ) + 16 );
            if ( uListEntry == 0 )
                return 0;

            long uPlayerPawn = ReadMemory( uListEntry + 120 * ( uHandle & 0x1FF ) );

            return uPlayerPawn;
        }

        public static long ReadMemory( DLL iModule, long uOffset ) => 
            G.Memory.ReadMemory<long>( $"{ Modules[(int)iModule] }+{ _( uOffset ) }" );
        public static long ReadMemory( long uBase, long uOffset ) =>
            G.Memory.ReadMemory<long>( $"{ _( uBase + uOffset ) }" );
        public static T ReadMemory<T>( long uBase, long uOffset ) =>
            G.Memory.ReadMemory<T>( $"{_( uBase + uOffset )}" );
        public static long ReadMemory( long uBase ) =>
            G.Memory.ReadMemory<long>( $"{_( uBase )}" );
        public static T ReadMemory<T>( long uBase ) =>
            G.Memory.ReadMemory<T>( $"{_( uBase )}" );
    }

    enum EFlags {
        FL_ONGROUND = ( 1 << 0 ), // entity is at rest / on the ground
        FL_DUCKING = ( 1 << 1 ), // player is fully crouched/uncrouched
        FL_ANIMDUCKING = ( 1 << 2 ), // player is in the process of crouching or uncrouching but could be in transition
        FL_WATERJUMP = ( 1 << 3 ), // player is jumping out of water
        FL_ONTRAIN = ( 1 << 4 ), // player is controlling a train, so movement commands should be ignored on client during prediction
        FL_INRAIN = ( 1 << 5 ), // entity is standing in rain
        FL_FROZEN = ( 1 << 6 ), // player is frozen for 3rd-person camera
        FL_ATCONTROLS = ( 1 << 7 ), // player can't move, but keeps key inputs for controlling another entity
        FL_CLIENT = ( 1 << 8 ), // entity is a client (player)
        FL_FAKECLIENT = ( 1 << 9 ), // entity is a fake client, simulated server side; don't send network messages to them
        FL_INWATER = ( 1 << 10 ), // entity is in water
        FL_FLY = ( 1 << 11 ),
        FL_SWIM = ( 1 << 12 ),
        FL_CONVEYOR = ( 1 << 13 ),
        FL_NPC = ( 1 << 14 ),
        FL_GODMODE = ( 1 << 15 ),
        FL_NOTARGET = ( 1 << 16 ),
        FL_AIMTARGET = ( 1 << 17 ),
        FL_PARTIALGROUND = ( 1 << 18 ), // entity is standing on a place where not all corners are valid
        FL_STATICPROP = ( 1 << 19 ), // entity is a static property
        FL_GRAPHED = ( 1 << 20 ),
        FL_GRENADE = ( 1 << 21 ),
        FL_STEPMOVEMENT = ( 1 << 22 ),
        FL_DONTTOUCH = ( 1 << 23 ),
        FL_BASEVELOCITY = ( 1 << 24 ), // entity have applied base velocity this frame
        FL_WORLDBRUSH = ( 1 << 25 ), // entity is not moveable/removeable brush (part of the world, but represented as an entity for transparency or something)
        FL_OBJECT = ( 1 << 26 ),
        FL_KILLME = ( 1 << 27 ), // entity is marked for death and will be freed by the game
        FL_ONFIRE = ( 1 << 28 ),
        FL_DISSOLVING = ( 1 << 29 ),
        FL_TRANSRAGDOLL = ( 1 << 30 ), // entity is turning into client-side ragdoll
        FL_UNBLOCKABLE_BY_PLAYER = ( 1 << 31 )
    };
}
