using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBoxTrigger : MonoBehaviour
{
    private ToolBoxSpawner _spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        GetComponent<SphereCollider>().enabled = false;
        _spawner.isFound = true;
        Destroy(gameObject);
    }

    private void Start()
    {
        _spawner = GameObject.Find("ToolBoxSpawns").GetComponent<ToolBoxSpawner>();
    }
}
