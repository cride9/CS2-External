using client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.src.classes {
    internal class Weapon {

        public long uBase;
        public Weapon( long _ ) => uBase = _;

        public int GetClip1( ) =>
            memory.Read<int>( uBase + C_BasePlayerWeapon.m_iClip1 );
        public int GetClip2( ) =>
            memory.Read<int>( uBase + C_BasePlayerWeapon.m_iClip2 );
        public int GetReserveAmmo( ) =>
            memory.Read<int>( uBase + C_BasePlayerWeapon.m_pReserveAmmo );
        public long GetDataBase( ) =>
            memory.Read<int>( uBase + (C_BaseEntity.m_nSubclassID + 0x8));
        public bool IsValid( ) =>
            uBase != 0;
    }
}
