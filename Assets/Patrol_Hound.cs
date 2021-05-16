using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Hound : MonoBehaviour
{
    public float speed;
    public float distance;

    Animator myanimator;

    public float amount = 20.0f;

    private bool movingRight = true;

    public Transform groundDetector;

    Rigidbody2D rb;

    Collider2D attackcol;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        attackcol = GameObject.Find("Hound").GetComponent<Collider2D>();
    }

    void Update()
    {
       transform.Translate(Vector2.right * speed * Time.deltaTime);
 
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Health_and_Damage>().Subtract_life_player(amount);

            collision.SendMessage("EnemyKnockBack", transform.position.x);
        }
    }
}
