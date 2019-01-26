using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        public Button loadGameButton;
        private GameManager _gameManager;

        private void RefreshButtons()
        {
            if (loadGameButton != null)
                loadGameButton.interactable = _gameManager.CanLoadGame();
        }

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            RefreshButtons();
        }
    }
}
