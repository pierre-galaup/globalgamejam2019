using System;

namespace Save
{
    [Serializable]
    public class SaveObject
    {
        public int daysPassed;
        public int currentMoney;
        public int maxHp;
        public int maxAmmo;
        public int dmgPerFire;
        public int fireRate;
    }
}
