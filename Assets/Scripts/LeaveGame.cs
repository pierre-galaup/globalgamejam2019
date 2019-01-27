using Managers;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class LeaveGame : MonoBehaviour
{
    [SerializeField]
    private readonly GameOverManager gameOverManager;

    [SerializeField]
    private PauseManager pauseManager;

    [SerializeField]
    private Canvas dialogCanvas;

    [SerializeField]
    private GameObject bonusPanel;

    [SerializeField]
    public PlayerHealth playerHealth;

    [SerializeField]
    private ToolBoxSpawner toolBoxSpawner;

    private GameManager _gameManager;
    private Text _bonusText;
    private int _previousZombiesKilled;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _bonusText = bonusPanel.GetComponentInChildren<Text>();
        _previousZombiesKilled = _gameManager.StatsManager.totalZombiesKilled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || !toolBoxSpawner.isFound)
        {
            return;
        }

        if (dialogCanvas.enabled)
        {
            return;
        }

        pauseManager.Pause();
        dialogCanvas.enabled = true;
    }

    public void OnDialogYes()
    {
        pauseManager.Pause();
        GetComponent<SphereCollider>().enabled = false;
        dialogCanvas.enabled = false;
        bonusPanel.SetActive(true);

        int zombiesKilled = _gameManager.StatsManager.totalZombiesKilled - _previousZombiesKilled;
        int bonusValue = Constants.BonusValueCalculator(_gameManager.daysPassed, zombiesKilled);

        _gameManager.PlayerManager.CurrentMoney += bonusValue;

        _bonusText.text = $"You earned a bonus of {bonusValue} resources";
        playerHealth.currentHealth = 0;
    }

    public void OnDialogNo()
    {
        dialogCanvas.enabled = false;
        pauseManager.Pause();
    }
}