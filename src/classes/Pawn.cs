using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.src.classes {
    public class Pawn {

        public long uBase;
        public Pawn( long _ ) => uBase = _;

        public int GetHealth() =>
           ( int )FN.ReadMemory( uBase, C_BaseEntity.m_iHealth );
        public int GetArmor( ) =>
            ( int )FN.ReadMemory( uBase, CCSPlayerController.m_iPawnArmor );
        public bool IsAlive( ) =>
            FN.ReadMemory<bool>( uBase, CCSPlayerController.m_bPawnIsAlive );
        public bool HasDefuser( ) =>
            FN.ReadMemory<bool>( uBase, CCSPlayerController.m_bPawnHasDefuser );
        public int GetFlags( ) =>
            FN.ReadMemory<int>( uBase, C_BaseEntity.m_fFlags );


        internal string ToString( ) {

            return $"0x{uBase:X}";
        }
    }
}
