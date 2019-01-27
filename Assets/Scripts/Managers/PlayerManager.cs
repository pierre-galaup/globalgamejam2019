using System;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public event EventHandler MoneyChanged;

        public int CurrentMoney
        {
            get => currentMoney;
            set
            {
                if (value == currentMoney)
                    return;
                currentMoney = value;
                MoneyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public int maxHealthPoints = 100;

        public int maxAmmoNumber = 60;

        public int damagesPerFire = 30;

        public float fireRate = 2;

        [SerializeField]
        private int currentMoney = 250;
    }
}