using UnityEngine;

public class ToolBoxSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject toolBox;

    public bool isFound = false;

    private void Awake()
    {
        var index = Random.Range(0, spawnPoints.Length);
        Instantiate(toolBox, spawnPoints[index], false);
    }

}
