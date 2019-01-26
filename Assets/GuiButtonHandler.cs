using Camp;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GuiButtonHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject shopCanvas;

    [SerializeField]
    private MoveCarCamp moveCarCamp;

    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    public void ShowShop()
    {
        shopCanvas.SetActive(true);
    }

    public void StartExplore()
    {
        moveCarCamp.MoveCar(LoadExplorationScene);
    }

    public void HideShop()
    {
        shopCanvas.SetActive(false);
    }

    private void LoadExplorationScene()
    {
        SceneManager.LoadScene("PlayArea");
    }
}
