using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform player;               // Reference to the player's position.
        private PlayerHealth playerHealth;      // Reference to the player's health.
        private EnemyHealth enemyHealth;        // Reference to this enemy's health.
        private UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

        [SerializeField]
        private float speedMultiplier;

        private void Awake()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

            var animator = GetComponent<Animator>();
            animator.SetFloat("SpeedMultiplier", speedMultiplier);

            var navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.speed = navMeshAgent.speed * speedMultiplier;
        }

        private void Update()
        {
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination(player.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
    }
}