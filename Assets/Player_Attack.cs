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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag=="Player" || collision.tag == "Ground" || collision.tag == "Platform" || collision.tag == "Wall" 
            || collision.tag == "Wall_Jumping")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy" || collision.tag == "Boss")
        {
            Destroy(gameObject);
            collision.GetComponent<Health_and_Damage>().Subtract_life(damage);
        }

        if (collision.tag == "Boss") 
        {
            Destroy(gameObject);
            collision.GetComponent<Health_and_Damage>().Subtract_life_boss(damage);
        }
    }
}
