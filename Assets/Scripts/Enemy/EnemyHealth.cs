using Managers;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public int currentHealth;                   // The current health the enemy has.
        public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
        public AudioClip deathClip;                 // The sound to play when the enemy dies.

        private Animator anim;                              // Reference to the animator.
        private AudioSource enemyAudio;                     // Reference to the audio source.
        private ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
        private CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
        private bool isDead;                                // Whether the enemy is dead.
        private bool isSinking;                             // Whether the enemy has started sinking through the floor.
        private StatsManager _statsManager;
        private PlayerManager _playerManager;
        private int _moneyValue;

        private void Awake()
        {
            _statsManager = GameManager.Instance.StatsManager;
            _playerManager = GameManager.Instance.PlayerManager;

            // Setting up the references.
            anim = GetComponent<Animator>();
            enemyAudio = GetComponent<AudioSource>();
            hitParticles = GetComponentInChildren<ParticleSystem>();
            capsuleCollider = GetComponent<CapsuleCollider>();

            // Setting the current health when the enemy first spawns.
            currentHealth = Constants.ZombieHealthCalculator(GameManager.Instance.daysPassed);
            _moneyValue = Constants.ZombieMoneyValueCalculator(GameManager.Instance.daysPassed);
        }

        private void Update()
        {
            // If the enemy should be sinking...
            if (isSinking)
            {
                // ... move the enemy down by the sinkSpeed per second.
                transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }

        public void TakeDamage(int amount, Vector3 hitPoint)
        {
            // If the enemy is dead...
            if (isDead)
            {
                // ... no need to take damage so exit the function.
                return;
            }

            // Play the hurt sound effect.
            enemyAudio.Play();

            _statsManager.damagesDealt += amount;

            // Reduce the current health by the amount of damage sustained.
            currentHealth -= amount;

            // Set the position of the particle system to where the hit was sustained.
            hitParticles.transform.position = hitPoint;

            // And play the particles.
            hitParticles.Play();

            // If the current health is less than or equal to zero...
            if (currentHealth <= 0)
            {
                // ... the enemy is dead.
                Death();
                _playerManager.CurrentMoney += _moneyValue;
                ++_statsManager.totalZombiesKilled;
                _statsManager.moneyEarned += _moneyValue;
            }
        }

        private void Death()
        {
            // The enemy is dead.
            isDead = true;

            // Turn the collider into a trigger so shots can pass through it.
            capsuleCollider.isTrigger = true;
            // Tell the animator that the enemy is dead.
            anim.SetTrigger("Dead");

            // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
            enemyAudio.clip = deathClip;
            enemyAudio.Play();
        }

        public void StartSinking()
        {
            // Find and disable the Nav Mesh Agent.
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
            GetComponent<Rigidbody>().isKinematic = true;

            // The enemy should no sink.
            isSinking = true;

            // Increase the score by the enemy's score value.
            // After 2 seconds destory the enemy.
            Destroy(gameObject, 2f);
        }
    }
}