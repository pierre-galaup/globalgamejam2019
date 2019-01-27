using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ShopManager : MonoBehaviour
    {
        public double hpUpgradeMultiplier = 1.1;
        public double ammoUpgradeMultiplier = 1.3;
        public double damagesUpgradeMultiplier = 1.4;
        public float fireRateUpgradeMultiplier = 1.25f;

        public Button updatePlayerHpButton;
        public Button updatePlayerAmmoButton;
        public Button updatePlayerDamagesButton;
        public Button updatePlayerFireRateButton;

        public TextMeshProUGUI updatePlayerHPPriceText;
        public TextMeshProUGUI updatePlayerAmmoPriceText;
        public TextMeshProUGUI updatePlayerDamagesPriceText;
        public TextMeshProUGUI updatePlayerFireRatePriceText;

        public TextMeshProUGUI updatePlayerHPBeforeValueText;
        public TextMeshProUGUI updatePlayerHPAfterValueText;
        public TextMeshProUGUI updatePlayerAmmoBeforeValueText;
        public TextMeshProUGUI updatePlayerAmmoAfterValueText;
        public TextMeshProUGUI updatePlayerDamagesBeforeValueText;
        public TextMeshProUGUI updatePlayerDamagesAfterValueText;
        public TextMeshProUGUI updatePlayerFireRateBeforeValueText;
        public TextMeshProUGUI updatePlayerFireRateAfterValueText;

        private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager = GameManager.Instance.PlayerManager;
            if (updatePlayerHpButton == null)
            {
                throw new ArgumentNullException(nameof(updatePlayerHpButton));
            }

            if (updatePlayerAmmoButton == null)
            {
                throw new ArgumentNullException(nameof(updatePlayerAmmoButton));
            }

            if (updatePlayerDamagesButton == null)
            {
                throw new ArgumentNullException(nameof(updatePlayerDamagesButton));
            }

            if (updatePlayerFireRateButton == null)
            {
                throw new ArgumentNullException(nameof(updatePlayerFireRateButton));
            }

            RefreshButtons();
        }

        public void UpgradePlayerHp()
        {
            if (_playerManager.maxHealthPoints * 2 > _playerManager.CurrentMoney)
            {
                return;
            }

            Debug.Log("Buy HP upgrade");
            _playerManager.CurrentMoney -= _playerManager.maxHealthPoints * 2;
            _playerManager.maxHealthPoints = (int)(_playerManager.maxHealthPoints * hpUpgradeMultiplier);

            RefreshButtons();
        }

        public void UpgradePlayerAmmo()
        {
            if (_playerManager.maxAmmoNumber * 4 > _playerManager.CurrentMoney)
            {
                return;
            }

            Debug.Log("Buy ammo upgrade");
            _playerManager.CurrentMoney -= _playerManager.maxAmmoNumber * 4;
            _playerManager.maxAmmoNumber = (int)(_playerManager.maxAmmoNumber * ammoUpgradeMultiplier);

            RefreshButtons();
        }

        public void UpgradePlayerDamages()
        {
            if (_playerManager.damagesPerFire * 6 > _playerManager.CurrentMoney)
            {
                return;
            }

            Debug.Log("Buy dmg upgrade");
            _playerManager.CurrentMoney -= _playerManager.damagesPerFire * 6;
            _playerManager.damagesPerFire = (int)(_playerManager.damagesPerFire * damagesUpgradeMultiplier);

            RefreshButtons();
        }

        public void UpgradePlayerFireRate()
        {
            if (_playerManager.fireRate * 100 > _playerManager.CurrentMoney)
            {
                return;
            }

            Debug.Log("Buy FR upgrade");
            _playerManager.CurrentMoney -= (int)(_playerManager.fireRate * 100);
            _playerManager.fireRate = (_playerManager.fireRate * fireRateUpgradeMultiplier);

            RefreshButtons();
        }

        private void RefreshButtons()
        {
            int nextHealthPrice = _playerManager.maxHealthPoints * 2;
            int nextAmmoPrice = _playerManager.maxAmmoNumber * 4;
            int nextDamagePrice = _playerManager.damagesPerFire * 6;
            int nextFireRatePrice = (int)(_playerManager.fireRate * 100);

            updatePlayerHPPriceText.text = nextHealthPrice + " $";
            updatePlayerAmmoPriceText.text = nextAmmoPrice + " $";
            updatePlayerDamagesPriceText.text = nextDamagePrice + " $";
            updatePlayerFireRatePriceText.text = nextFireRatePrice + " $";

            updatePlayerHPBeforeValueText.text = _playerManager.maxHealthPoints.ToString();
            updatePlayerHPAfterValueText.text = (_playerManager.maxHealthPoints * hpUpgradeMultiplier).ToString(CultureInfo.InvariantCulture);
            updatePlayerAmmoBeforeValueText.text = _playerManager.maxAmmoNumber.ToString();
            updatePlayerAmmoAfterValueText.text = (_playerManager.maxAmmoNumber * ammoUpgradeMultiplier).ToString(CultureInfo.InvariantCulture);
            updatePlayerDamagesBeforeValueText.text = _playerManager.damagesPerFire.ToString();
            updatePlayerDamagesAfterValueText.text = (_playerManager.damagesPerFire * damagesUpgradeMultiplier).ToString(CultureInfo.InvariantCulture);
            updatePlayerFireRateBeforeValueText.text = _playerManager.fireRate.ToString(CultureInfo.InvariantCulture);
            updatePlayerFireRateAfterValueText.text = (_playerManager.fireRate * fireRateUpgradeMultiplier).ToString("0.00",CultureInfo.InvariantCulture);

            if (nextHealthPrice > _playerManager.CurrentMoney)
            {
                updatePlayerHpButton.interactable = false;
            }

            if (nextAmmoPrice > _playerManager.CurrentMoney)
            {
                updatePlayerAmmoButton.interactable = false;
            }

            if (nextDamagePrice > _playerManager.CurrentMoney)
            {
                updatePlayerDamagesButton.interactable = false;
            }

            if (nextFireRatePrice > _playerManager.CurrentMoney)
            {
                updatePlayerFireRateButton.interactable = false;
            }
        }
    }
}