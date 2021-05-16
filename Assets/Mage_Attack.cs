using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Attack : MonoBehaviour
{
    public float speedX = 5f;
    float speedY = 0f;
    public float amount = 20.0f;
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
        Destroy(gameObject, 1f);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health_and_Damage>().Subtract_life_player(amount);
            Destroy(gameObject);
            collision.SendMessage("EnemyKnockBack", transform.position.x);
        }

        if (collision.CompareTag ("Wall"))
            Destroy(gameObject);


    }
}
