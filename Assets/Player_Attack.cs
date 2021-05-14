using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public float speedX = 10f;
    public float damage = 5f;
    float speedY = 0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speedX, speedY);
        Destroy(gameObject, 0.5f);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") 
            || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Wall_Jumping") || collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health_and_Damage>().Subtract_life(damage);
            Destroy(gameObject);

        }

        if (collision.tag == "Wall")
            Destroy(gameObject);
    }
}
