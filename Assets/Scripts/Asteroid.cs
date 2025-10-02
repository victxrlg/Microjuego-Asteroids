using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public int points;
    public bool canSplit;
    public GameObject smallerAsteroidPrefab;
    public float splitAngle = 45f;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = 0;
        rb.angularDamping = 0;
        rb.linearVelocity = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized * speed;
        rb.angularVelocity = Random.Range(-50f, 50f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(++points);

            if (canSplit && smallerAsteroidPrefab != null)
                SplitAsteroid(other.transform);

            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
    void SplitAsteroid(Transform bullet)
    {
        Vector2 bulletDirection = bullet.up; 
        
        float angle1 = splitAngle / 2f;
        float angle2 = -splitAngle / 2f;
        
        Vector2 direction1 = RotateVector(bulletDirection, angle1);
        Vector2 direction2 = RotateVector(bulletDirection, angle2);
        
        CreateSmallAsteroid(direction1);
        
        CreateSmallAsteroid(direction2);
    }
    
    void CreateSmallAsteroid(Vector2 direction)
    {
        GameObject smallAsteroid = PoolManager.Instance.GetSmallAsteroid();
        if (smallAsteroid != null)
        {
            Rigidbody2D smallRb = smallAsteroid.GetComponent<Rigidbody2D>();
            if (smallRb != null)
            {
                smallRb.linearVelocity = direction * speed * 0.8f; 
                smallRb.angularVelocity = Random.Range(-50f, 50f);
            }
        }
        
        
    }
    
    Vector2 RotateVector(Vector2 v, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);
        
        return new Vector2(
            v.x * cos - v.y * sin,
            v.x * sin + v.y * cos
        );
    }
}
