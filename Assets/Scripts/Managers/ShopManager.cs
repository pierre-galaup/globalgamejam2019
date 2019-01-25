using System;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ShopManager : MonoBehaviour
    {
        public double HpUpgradeMultiplier = 1.1;
        public double AmmoUpgradeMultiplier = 1.3;
        public double DamagesUpgradeMultiplier = 1.4;
        public double FireRateUpgradeMultiplier = 1.25;

        public Button UpdatePlayerHpButton;
        public Button UpdatePlayerAmmoButton;
        public Button UpdatePlayerDamagesButton;
        public Button UpdatePlayerFireRateButton;

        private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager = GameManager.Instance.PlayerManager;
            if (UpdatePlayerHpButton == null) throw new ArgumentNullException(nameof(UpdatePlayerHpButton));
            if (UpdatePlayerAmmoButton == null) throw new ArgumentNullException(nameof(UpdatePlayerAmmoButton));
            if (UpdatePlayerDamagesButton == null) throw new ArgumentNullException(nameof(UpdatePlayerDamagesButton));
            if (UpdatePlayerFireRateButton == null) throw new ArgumentNullException(nameof(UpdatePlayerFireRateButton));

            RefreshButtons();
        }

        public bool UpgradePlayerHp()
        {
            if (_playerManager.MaxHealthPoints * 100 < _playerManager.CurrentMoney)
                return false;

            _playerManager.CurrentMoney -= _playerManager.MaxHealthPoints * 100;
            _playerManager.MaxHealthPoints = (int) (_playerManager.MaxHealthPoints * HpUpgradeMultiplier);

            RefreshButtons();
            return true;
        }

        public bool UpgradePlayerAmmo()
        {
            if (_playerManager.MaxAmmoNumber * 100 < _playerManager.CurrentMoney)
                return false;

            _playerManager.CurrentMoney -= _playerManager.MaxAmmoNumber * 100;
            _playerManager.MaxAmmoNumber = (int)(_playerManager.MaxAmmoNumber * AmmoUpgradeMultiplier);

            RefreshButtons();
            return true;
        }

        public bool UpgradePlayerDamages()
        {
            if (_playerManager.DamagesPerFire * 100 < _playerManager.CurrentMoney)
                return false;

            _playerManager.CurrentMoney -= _playerManager.DamagesPerFire * 100;
            _playerManager.DamagesPerFire = (int)(_playerManager.DamagesPerFire * DamagesUpgradeMultiplier);

            RefreshButtons();
            return true;
        }

        public bool UpgradePlayerFireRate()
        {
            if (_playerManager.FireRate * 1000 < _playerManager.CurrentMoney)
                return false;

            _playerManager.CurrentMoney -= (int)_playerManager.FireRate * 1000;
            _playerManager.FireRate = (int)(_playerManager.FireRate * FireRateUpgradeMultiplier);

            RefreshButtons();
            return true;
        }

        private void RefreshButtons()
        {
            if (_playerManager.MaxHealthPoints * 100 > _playerManager.CurrentMoney)
                UpdatePlayerHpButton.interactable = false;
            if (_playerManager.MaxAmmoNumber * 100 > _playerManager.CurrentMoney)
                UpdatePlayerAmmoButton.interactable = false;
            if (_playerManager.DamagesPerFire * 100 > _playerManager.CurrentMoney)
                UpdatePlayerDamagesButton.interactable = false;
            if (_playerManager.FireRate * 1000 > _playerManager.CurrentMoney)
                UpdatePlayerFireRateButton.interactable = false;
        }

    }
}
