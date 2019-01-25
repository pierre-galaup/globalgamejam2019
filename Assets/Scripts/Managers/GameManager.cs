using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public PlayerManager PlayerManager { get; private set; }

        private void Awake()
        {
            Instance = this;
            PlayerManager = GetComponent<PlayerManager>();
        }
    }
}
