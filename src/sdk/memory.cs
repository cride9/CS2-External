using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.src {
    public enum DLL {

        CLIENT,
        ENGINE
    }

    public class memory {

        private static string[ ] Modules = new string[ ] { "client.dll", "engine2.dll" };
        public static string _( int number ) => ( ( $"0x{number:X}" ) );
        public static string _( long number ) => ( ( $"0x{number:X}" ) );

        private static Dictionary<Type, string> types = new Dictionary<Type, string>( )
        {
            { typeof(float), "float" },
            { typeof(int), "int" },
            { typeof(string), "string" },
            { typeof(double), "double" },
            { typeof(long), "long" },
        };

        private string address;

        /* Address decleration (every possible solution) */
        public memory( string input ) =>
            address = input;
        public memory( DLL iModule, long uOffset ) =>
            address = $"{Modules[ ( int )iModule ]}+{_( uOffset )}";
        public memory( long uBase, long uOffset ) =>
            address = _( uBase + uOffset );
        public memory( long uBase ) =>
            address = _( uBase );

        /* Decleared address functions (dynamic) */
        public T Read<T>( ) => G.Memory.ReadMemory<T>( address );
        public bool Write<T>( long value ) => G.Memory.WriteMemory( address, types[ typeof( T ) ], value.ToString() );
        public bool Write<T>( float value ) => G.Memory.WriteMemory( address, types[ typeof( T ) ], value.ToString() );
        public bool Write<T>( double value ) => G.Memory.WriteMemory( address, types[ typeof( T ) ], value.ToString() );

        /* Non-decleared address functions (static) */
        public static T Read<T>( long uOffset ) => G.Memory.ReadMemory<T>( $"{_( uOffset )}" );
        public static T Read<T>( long uOffset, long uPadding ) => G.Memory.ReadMemory<T>( $"{_( uOffset + uPadding )}" );
        public static T Read<T>( DLL iModule, long uOffset ) => G.Memory.ReadMemory<T>( $"{Modules[ ( int )iModule ]}+{_( uOffset )}" );
        public static bool Write<T>( DLL iModule, long uOffset, long value ) => G.Memory.WriteMemory( $"{Modules[ ( int )iModule ]}+{_( uOffset )}", types[ typeof( T ) ], value.ToString( ) );
        public static bool Write<T>( DLL iModule, long uOffset, float value ) => G.Memory.WriteMemory( $"{Modules[ ( int )iModule ]}+{_( uOffset )}", types[ typeof( T ) ], value.ToString( ) );
        public static bool Write<T>( DLL iModule, long uOffset, double value ) => G.Memory.WriteMemory( $"{Modules[ ( int )iModule ]}+{_( uOffset )}", types[ typeof( T ) ], value.ToString( ) );
        public static Task<IEnumerable<long>> PatternScan( DLL iModule, string szPattern ) => G.Memory.AoBScan( szPattern, false, true, Modules[ ( int )iModule ] );
    }
}
