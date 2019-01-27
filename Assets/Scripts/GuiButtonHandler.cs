using Camp;
using Managers;
using Story;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GuiButtonHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject shopCanvas;

    [SerializeField]
    private MoveCarCamp moveCarCamp;

    [SerializeField]
    private Button exploreButton;

    [SerializeField]
    private Button shopButton;

    [SerializeField]
    private Button _closeStoryButton;

    [SerializeField]
    private DeployStoryText _deployStoryText;

    [FormerlySerializedAs("MenuDialogCanvas")] [SerializeField]
    private Canvas menuDialogCanvas;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        shopCanvas.SetActive(false);
    }

    public void ShowShop()
    {
        if (shopCanvas.activeSelf)
        {
            return;
        }

        exploreButton.interactable = false;
        shopButton.interactable = false;
        shopCanvas.SetActive(true);
    }

    public void StartExplore()
    {
        shopButton.interactable = false;
        exploreButton.interactable = false;

        if (_gameManager.daysPassed == 0)
        {
            _deployStoryText.DisplayText(1);
            _closeStoryButton.onClick.RemoveAllListeners();
            _closeStoryButton.onClick.AddListener(() => moveCarCamp.MoveCar(LoadExplorationScene));
        }
        else
        {
            moveCarCamp.MoveCar(LoadExplorationScene);
        }
    }

    public void HideShop()
    {
        if (!shopCanvas.activeSelf)
        {
            return;
        }

        shopCanvas.SetActive(false);
        exploreButton.interactable = true;
        shopButton.interactable = transform;
    }

    public void ShowQuitMenu()
    {
        menuDialogCanvas.enabled = true;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void HideMenuDialog()
    {
        menuDialogCanvas.enabled = false;
    }

    private void LoadExplorationScene()
    {
        SceneManager.LoadScene("PlayArea");
    }

    private void Reset()
    {
        _closeStoryButton = null;
        _deployStoryText = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowQuitMenu();
        }
    }
}