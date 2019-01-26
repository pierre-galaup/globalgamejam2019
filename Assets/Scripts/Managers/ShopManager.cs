using System;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ShopManager : MonoBehaviour
    {
        public double hpUpgradeMultiplier = 1.1;
        public double ammoUpgradeMultiplier = 1.3;
        public double damagesUpgradeMultiplier = 1.4;
        public double fireRateUpgradeMultiplier = 1.25;

        public Button updatePlayerHpButton;
        public Button updatePlayerAmmoButton;
        public Button updatePlayerDamagesButton;
        public Button updatePlayerFireRateButton;

        private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager = GameManager.Instance.PlayerManager;
            if (updatePlayerHpButton == null) throw new ArgumentNullException(nameof(updatePlayerHpButton));
            if (updatePlayerAmmoButton == null) throw new ArgumentNullException(nameof(updatePlayerAmmoButton));
            if (updatePlayerDamagesButton == null) throw new ArgumentNullException(nameof(updatePlayerDamagesButton));
            if (updatePlayerFireRateButton == null) throw new ArgumentNullException(nameof(updatePlayerFireRateButton));

            RefreshButtons();
        }

        public bool UpgradePlayerHp()
        {
            if (_playerManager.maxHealthPoints * 100 < _playerManager.CurrentMoney)
                return false;

            _playerManager.CurrentMoney -= _playerManager.maxHealthPoints * 100;
            _playerManager.maxHealthPoints = (int) (_playerManager.maxHealthPoints * hpUpgradeMultiplier);

            RefreshButtons();
            return true;
        }

        public bool UpgradePlayerAmmo()
        {
            if (_playerManager.maxAmmoNumber * 100 < _playerManager.CurrentMoney)
                return false;

            _playerManager.CurrentMoney -= _playerManager.maxAmmoNumber * 100;
            _playerManager.maxAmmoNumber = (int)(_playerManager.maxAmmoNumber * ammoUpgradeMultiplier);

            RefreshButtons();
            return true;
        }

        public bool UpgradePlayerDamages()
        {
            if (_playerManager.damagesPerFire * 100 < _playerManager.CurrentMoney)
                return false;

            _playerManager.CurrentMoney -= _playerManager.damagesPerFire * 100;
            _playerManager.damagesPerFire = (int)(_playerManager.damagesPerFire * damagesUpgradeMultiplier);

            RefreshButtons();
            return true;
        }

        public bool UpgradePlayerFireRate()
        {
            if (_playerManager.fireRate * 1000 < _playerManager.CurrentMoney)
                return false;

            _playerManager.CurrentMoney -= (int)_playerManager.fireRate * 1000;
            _playerManager.fireRate = (int)(_playerManager.fireRate * fireRateUpgradeMultiplier);

            RefreshButtons();
            return true;
        }

        private void RefreshButtons()
        {
            if (_playerManager.maxHealthPoints * 100 > _playerManager.CurrentMoney)
                updatePlayerHpButton.interactable = false;
            if (_playerManager.maxAmmoNumber * 100 > _playerManager.CurrentMoney)
                updatePlayerAmmoButton.interactable = false;
            if (_playerManager.damagesPerFire * 100 > _playerManager.CurrentMoney)
                updatePlayerDamagesButton.interactable = false;
            if (_playerManager.fireRate * 1000 > _playerManager.CurrentMoney)
                updatePlayerFireRateButton.interactable = false;
        }

    }
}
