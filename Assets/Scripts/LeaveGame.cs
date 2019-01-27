using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class LeaveGame : MonoBehaviour
{

    [SerializeField]
    private GameOverManager gameOverManager;

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
