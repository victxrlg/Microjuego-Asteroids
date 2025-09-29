using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject asteroidPrefab;
    public Transform[] spawners;

    void Start()
    {
        // DEBUG: Verificar spawners
        if (spawners == null || spawners.Length == 0)
        {
            Debug.LogError("¡No hay spawners asignados!");
            return;
        }
        
        Debug.Log($"Número de spawners: {spawners.Length}");
        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawners[i] != null)
            {
                Debug.Log($"Spawner {i}: {spawners[i].name} en posición {spawners[i].position}");
            }
            else
            {
                Debug.LogError($"Spawner {i} es NULL!");
            }
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
                
                Debug.Log($"Spawneando en: {selectedSpawner.position}");
                
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