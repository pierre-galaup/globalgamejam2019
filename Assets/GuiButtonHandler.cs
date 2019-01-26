using Camp;
using Managers;
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

    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager = GameManager.Instance;
        shopCanvas.SetActive(false);
    }

    public void ShowShop()
    {
        if (shopCanvas.activeSelf)
            return;
        exploreButton.interactable = false;
        shopButton.interactable = false;
        shopCanvas.SetActive(true);
    }

    public void StartExplore()
    {
        shopButton.interactable = false;
        exploreButton.interactable = false;
        moveCarCamp.MoveCar(LoadExplorationScene);
    }

    public void HideShop()
    {
        if (!shopCanvas.activeSelf)
            return;
        shopCanvas.SetActive(false);
        exploreButton.interactable = true;
        shopButton.interactable = transform;
    }

    private void LoadExplorationScene()
    {
        SceneManager.LoadScene("PlayArea");
    }
}
