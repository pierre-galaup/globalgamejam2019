using Managers;
using UnityEngine;

namespace Story
{
    public class SoldierInCamp : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(GameManager.Instance.soldierSaved);
        }
    }
}