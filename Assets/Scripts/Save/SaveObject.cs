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
        public float fireRate;
        public bool soldierSaved;

        // stats
        public int totalZombiesKilled;

        public int totalAmmoFired;
        public int moneyEarned;
        public int damagesDealt;
        public int damagesTaken;
        public int deaths;
    }
}