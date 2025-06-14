using UnityEngine;

public class BarricadeSpawner : MonoBehaviour
{
    public GameObject barricadePrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        foreach (Transform point in spawnPoints)
        {
            Instantiate(barricadePrefab, point.position, point.rotation);
        }
    }
}
