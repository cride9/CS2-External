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
            memory.Read<int>( uBase, C_BaseEntity.m_iHealth );
        public int GetArmor( ) =>
            memory.Read<int>( uBase, CCSPlayerController.m_iPawnArmor );
        public bool IsAlive( ) =>
            memory.Read<bool>( uBase, CCSPlayerController.m_bPawnIsAlive );
        public bool HasDefuser( ) =>
            memory.Read<bool>( uBase, CCSPlayerController.m_bPawnHasDefuser );
        public int GetFlags( ) =>
            memory.Read<int>( uBase, C_BaseEntity.m_fFlags );

        internal string ToString( ) =>
            $"0x{uBase:X}";
    }
}
