using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;

    private Rigidbody2D rb;
    private float mx;
    private float my;
    private float fireTimer;
    private int playerHealth = 4; // Tambahkan variabel kesehatan pemain
    private Vector2 mousePos;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }

        if (playerHealth <= 0) // Tambahkan pengecekan jika kesehatan pemain kurang dari atau sama dengan 0
        {
            LevelManager.manager.GameOver();
            Destroy(gameObject);
        }

        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }
    private void UpdateAnimator()
    {
        bool isMoving = (mx != 0 || my != 0);
        animator.SetBool("IsMoving", isMoving);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }

    public void TakeDamage(int damage) // Tambahkan metode untuk mengurangi kesehatan pemain
    {
        playerHealth -= damage;
        Debug.Log("Player took " + damage + " damage. Current Health: " + playerHealth);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(1); // Inflik damage pada pemain ketika terkena peluru musuh
            LevelManager.manager.GameOver();
            Destroy(gameObject);
        }
    }
}
