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
            var upgradeCost = Constants.UpgradeHpCostCalculator(_playerManager.maxHealthPoints);
            if (upgradeCost > _playerManager.CurrentMoney)
            {
                return;
            }
            _playerManager.CurrentMoney -= upgradeCost;
            _playerManager.maxHealthPoints = Constants.UpgradeHpCalculator(_playerManager.maxHealthPoints);

            RefreshButtons();
        }

        public void UpgradePlayerAmmo()
        {
            var upgradeCost = Constants.UpgradeAmmoCostCalculator(_playerManager.maxAmmoNumber);
            if (upgradeCost > _playerManager.CurrentMoney)
            {
                return;
            }

            Debug.Log("Buy ammo upgrade");
            _playerManager.CurrentMoney -= upgradeCost;
            _playerManager.maxAmmoNumber = Constants.UpgradeAmmoCalculator(_playerManager.maxAmmoNumber);

            RefreshButtons();
        }

        public void UpgradePlayerDamages()
        {
            var upgradeCost = Constants.UpgradeDamageCostCalculator(_playerManager.damagesPerFire);
            if (upgradeCost > _playerManager.CurrentMoney)
            {
                return;
            }
            _playerManager.CurrentMoney -= upgradeCost;
            _playerManager.damagesPerFire = Constants.UpgradeDamageCalculator(_playerManager.damagesPerFire);

            RefreshButtons();
        }

        public void UpgradePlayerFireRate()
        {
            var upgradeCost = Constants.UpgradeFireRateCostCalculator(_playerManager.fireRate);
            if (upgradeCost > _playerManager.CurrentMoney)
            {
                return;
            }
            _playerManager.CurrentMoney -= upgradeCost;
            _playerManager.fireRate = Constants.UpgradeFireRate(_playerManager.fireRate);

            RefreshButtons();
        }

        private void RefreshButtons()
        {
            int nextHealthPrice = Constants.UpgradeHpCostCalculator(_playerManager.maxHealthPoints);
            int nextAmmoPrice = Constants.UpgradeAmmoCostCalculator(_playerManager.maxAmmoNumber);
            int nextDamagePrice = Constants.UpgradeDamageCostCalculator(_playerManager.damagesPerFire);
            int nextFireRatePrice = Constants.UpgradeFireRateCostCalculator(_playerManager.fireRate);

            updatePlayerHPPriceText.text = nextHealthPrice + " $";
            updatePlayerAmmoPriceText.text = nextAmmoPrice + " $";
            updatePlayerDamagesPriceText.text = nextDamagePrice + " $";
            updatePlayerFireRatePriceText.text = nextFireRatePrice + " $";

            updatePlayerHPBeforeValueText.text = _playerManager.maxHealthPoints.ToString();
            updatePlayerHPAfterValueText.text = Constants.UpgradeHpCalculator(_playerManager.maxHealthPoints).ToString(CultureInfo.InvariantCulture);
            updatePlayerAmmoBeforeValueText.text = _playerManager.maxAmmoNumber.ToString();
            updatePlayerAmmoAfterValueText.text = Constants.UpgradeAmmoCalculator(_playerManager.maxAmmoNumber).ToString(CultureInfo.InvariantCulture);
            updatePlayerDamagesBeforeValueText.text = _playerManager.damagesPerFire.ToString();
            updatePlayerDamagesAfterValueText.text = Constants.UpgradeDamageCalculator(_playerManager.damagesPerFire).ToString(CultureInfo.InvariantCulture);
            updatePlayerFireRateBeforeValueText.text = _playerManager.fireRate.ToString("0.00", CultureInfo.InvariantCulture);
            updatePlayerFireRateAfterValueText.text = Constants.UpgradeFireRate(_playerManager.fireRate).ToString("0.00",CultureInfo.InvariantCulture);

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