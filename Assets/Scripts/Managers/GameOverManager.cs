﻿using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's health.

        private Animator _anim;                          // Reference to the animator component.

        private void Awake()
        {
            // Set up the reference.
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            // If the player has run out of health...
            if (playerHealth.currentHealth <= 0)
                RunGameOver();
        }

        public void RunGameOver()
        {
            // ... tell the animator the game is over.
            _anim.SetTrigger("GameOver");

            StartCoroutine(LoadCamp());

        }

        public IEnumerator LoadCamp()
        {
            yield return new WaitForSecondsRealtime(4);
            ++GameManager.Instance.daysPassed;
            GameManager.Instance.SaveGame();
            SceneManager.LoadScene("Camp");
        }
    }
}