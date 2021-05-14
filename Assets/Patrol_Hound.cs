using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Hound : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetector;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
       transform.Translate(Vector2.right * speed * Time.deltaTime);
       // rb.velocity = Vector2.right * speed * Time.deltaTime;

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, distance);

        if (groundInfo.collider == false) 
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else 
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
