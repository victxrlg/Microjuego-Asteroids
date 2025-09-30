using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject asteroidPrefab;
    public Transform[] spawners;

    void Start()
    {
        if (spawners == null || spawners.Length == 0)
        {
            return;
        }
        
        
        
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            if (spawners != null && spawners.Length > 0)
            {
                Transform selectedSpawner = spawners[Random.Range(0, spawners.Length)];
                                
                Instantiate(
                    asteroidPrefab,
                    selectedSpawner.position,
                    Quaternion.identity
                );
            }
            
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}