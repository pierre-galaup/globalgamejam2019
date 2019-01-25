using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public PlayerManager PlayerManager { get; private set; }

        public int daysPassed = 0;

        public float EnemyHealthMultiplier => 1f + daysPassed * 1.1f;
        public float EnemyDamagesMultiplier => 1f + daysPassed * 1.1f;

        private void Awake()
        {
            Instance = this;
            PlayerManager = GetComponent<PlayerManager>();
        }
    }
}
