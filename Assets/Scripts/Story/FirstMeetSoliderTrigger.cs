using Managers;
using UnityEngine;

namespace Story
{
    public class FirstMeetSoliderTrigger : MonoBehaviour
    {
        [SerializeField]
        private Canvas _storyCanvas;

        private void Awake()
        {
            if (GameManager.Instance.soldierSaved || GameManager.Instance.daysPassed < 1)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }

            _storyCanvas.enabled = true;
            Time.timeScale = 0;
            GetComponent<SphereCollider>().enabled = false;
            GameManager.Instance.soldierSaved = true;
        }

        public void Resume()
        {
            Time.timeScale = 1;
            _storyCanvas.enabled = false;

            Destroy(gameObject);
        }
    }
}