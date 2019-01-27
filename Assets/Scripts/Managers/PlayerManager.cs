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

        public int maxHealthPoints = Constants.InitialPlayerHealthPoint;
        public int maxAmmoNumber = Constants.InitialAmmoNumber;
        public int damagesPerFire = Constants.InitialDamagesPerFire;
        public float fireRate = Constants.InitialFireRate;

        [SerializeField]
        private int currentMoney = Constants.InitialMoney;
    }
}