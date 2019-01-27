using Managers;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class LeaveGame : MonoBehaviour
{

    [SerializeField]
    private GameOverManager gameOverManager;

    [SerializeField]
    private PauseManager pauseManager;

    [SerializeField]
    private Canvas dialogCanvas;

    [SerializeField]
    private GameObject bonusPanel;

    [SerializeField]
    public PlayerHealth playerHealth;

    private GameManager _gameManager;
    private Text _bonusText;
    private bool _isPlayerOut;
    private int _previousZombiesKiled;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _isPlayerOut = false;
        _bonusText = bonusPanel.GetComponentInChildren<Text>();
        _previousZombiesKiled = _gameManager.StatsManager.totalZombiesKilled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isPlayerOut)
            return;
        _isPlayerOut = false;
        pauseManager.Pause();
        dialogCanvas.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isPlayerOut = true;
    }

    public void OnDialogYes()
    {
        pauseManager.Pause();
        dialogCanvas.enabled = false;
        bonusPanel.SetActive(true);

        var zombiesKilled = _gameManager.StatsManager.totalZombiesKilled - _previousZombiesKiled;
        Debug.Log($"ZombiKilled = {zombiesKilled}");
        var bonusValue = ((1 + _gameManager.daysPassed) * zombiesKilled) * 2;

        _gameManager.PlayerManager.CurrentMoney += bonusValue;

        _bonusText.text = $"You earned a bonus of {bonusValue} $";
        playerHealth.currentHealth = 0;
    }

    public void OnDialogNo()
    {
        dialogCanvas.enabled = false;
        pauseManager.Pause();
    }
}
