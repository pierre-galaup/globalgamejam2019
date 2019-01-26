using System;
using Managers;
using TMPro;
using UnityEngine;

public class MoneyUIRefresher : MonoBehaviour
{
    public TextMeshProUGUI uiMoneyText;
    public TextMeshProUGUI uiDaysPassedText;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _gameManager.PlayerManager.MoneyChanged += PlayerManagerOnMoneyChanged;
        uiDaysPassedText.text = _gameManager.daysPassed.ToString();
        UpdateUiText();
    }

    private void OnDestroy()
    {
        _gameManager.PlayerManager.MoneyChanged -= PlayerManagerOnMoneyChanged;
    }

    private void PlayerManagerOnMoneyChanged(object sender, EventArgs e)
    {
        UpdateUiText();
    }

    private void UpdateUiText()
    {
        uiMoneyText.text = $"{_gameManager.PlayerManager.CurrentMoney} $";
    }
}
