﻿using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public int currentHealth;                                   // The current health the player has.
        public Slider healthSlider;                                 // Reference to the UI's health bar.
        public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

        private Animator anim;                                              // Reference to the Animator component.
        private AudioSource playerAudio;                                    // Reference to the AudioSource component.
        private PlayerMovement playerMovement;                              // Reference to the player's movement.
        private PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
        private bool isDead;                                                // Whether the player is dead.
        private bool damaged;                                               // True when the player gets damaged.
        private PlayerManager _playerManager;
        private StatsManager _statsManager;

        private void Awake()
        {
            _playerManager = GameManager.Instance.PlayerManager;
            _statsManager = GameManager.Instance.StatsManager;

            // Setting up the references.
            anim = GetComponent<Animator>();
            playerAudio = GetComponent<AudioSource>();
            playerMovement = GetComponent<PlayerMovement>();
            playerShooting = GetComponentInChildren<PlayerShooting>();

            currentHealth = _playerManager.maxHealthPoints;
            healthSlider.maxValue = _playerManager.maxHealthPoints;
            healthSlider.value = currentHealth;
        }

        private void Update()
        {
            // If the player has just been damaged...
            if (damaged)
            {
                // ... set the colour of the damageImage to the flash colour.
                damageImage.color = flashColour;
            }
            // Otherwise...
            else
            {
                // ... transition the colour back to clear.
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // Reset the damaged flag.
            damaged = false;
        }

        public void TakeDamage(int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            // Play the hurt sound effect.
            playerAudio.Play();
            _statsManager.damagesTaken += amount;
            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death();
                ++_statsManager.deaths;
            }
        }

        private void Death()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
            GameObject.Find("GunBarrelEnd").GetComponent<PlayerShooting>().DisableEffects();

            // Tell the animator that the player is dead.
            anim.SetTrigger("Die");

            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            playerAudio.clip = deathClip;
            playerAudio.Play();

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
            GameObject.Find("GunBarrelEnd").GetComponent<PlayerShooting>().enabled = false;
        }
    }
}