using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public int points;
    void Start()
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
            if(ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(++points);
            }
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
