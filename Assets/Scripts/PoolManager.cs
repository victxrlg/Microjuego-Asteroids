using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public GameObject asteroidPrefab;
    public GameObject smallerAsteroidPrefab;
    public GameObject bulletPrefab;

    private List<GameObject> asteroidPool = new List<GameObject>();
    private List<GameObject> smallAsteroidPool = new List<GameObject>();
    private List<GameObject> bulletPool = new List<GameObject>();

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < 50; i++)
        {
            var obj = Instantiate(asteroidPrefab);
            obj.SetActive(false);
            asteroidPool.Add(obj);
        }

        for (int i = 0; i < 100; i++)
        {
            var obj = Instantiate(smallerAsteroidPrefab);
            obj.SetActive(false);
            smallAsteroidPool.Add(obj);
        }
        for (int i = 0; i < 200; i++)
        {
            var obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }

    public GameObject GetAsteroid() => GetFromPool(asteroidPool);
    public GameObject GetSmallAsteroid() => GetFromPool(smallAsteroidPool);
    public GameObject GetBullet() => GetFromPool(bulletPool);

    private GameObject GetFromPool(List<GameObject> pool)
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
}
