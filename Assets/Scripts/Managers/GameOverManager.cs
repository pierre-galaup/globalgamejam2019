using Player;
using UnityEngine;

namespace Managers
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's health.

        private Animator anim;                          // Reference to the animator component.

        private void Awake()
        {
            // Set up the reference.
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            // If the player has run out of health...
            if (playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the game is over.
                anim.SetTrigger("GameOver");
            }
        }
    }
}