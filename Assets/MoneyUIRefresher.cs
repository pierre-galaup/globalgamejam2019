using System;
using Managers;
using TMPro;
using UnityEngine;

public class MoneyUIRefresher : MonoBehaviour
{
    public TextMeshProUGUI uiMoneyText;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _gameManager.PlayerManager.MoneyChanged += PlayerManagerOnMoneyChanged;
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
        Debug.Log($"Player money: {_gameManager.PlayerManager.CurrentMoney} $");
        uiMoneyText.text = $"{_gameManager.PlayerManager.CurrentMoney} $";
    }
}
