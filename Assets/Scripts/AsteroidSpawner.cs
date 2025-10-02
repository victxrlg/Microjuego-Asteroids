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
                                
                GameObject asteroid = PoolManager.Instance.GetAsteroid();
                if (asteroid != null)
                {
                    asteroid.transform.position = selectedSpawner.position;
                    asteroid.transform.rotation = Quaternion.identity;
                    asteroid.SetActive(true); 
                }
            }
            
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}