using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float drag;
    public float angularSpeed;
    public float offsetBullet;
    public float shootRate;
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    private float vertical;
    private float horizontal;
    private bool shooting;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = drag;
    }
    void Update()
    {
        vertical = InputManager.Vertical;
        horizontal = InputManager.Horizontal;
        shooting = InputManager.Fire;
        Rotate();
        Shoot();
    }

    void FixedUpdate()
    {
        var forwardMotor = Mathf.Clamp(vertical, 0f, 1f);
        rb.AddForce(transform.right * acceleration * forwardMotor);
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
    private void Rotate()
    {
        if (horizontal == 0)
        {
            return;
        }
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);
    }
    private void Shoot()
    {
        if (shooting && canShoot)
        {
            StartCoroutine(FireRate());
        }
    }

    private IEnumerator FireRate()
    {
        canShoot = false;
        var pos = transform.right * offsetBullet + transform.position;
        var bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        Destroy(bullet, 5);

        yield return new WaitForSeconds(shootRate);

        canShoot = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



