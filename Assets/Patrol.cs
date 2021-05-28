using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance = 2f;
    public float stopDistance;
    public float retreatDistance;
    bool facingRight = true;

    public GameObject AttackLeft, AttackRight;
    Vector2 AttackPos;
    public float fireRate = 1f;
    float nextAttack = 0.0f;

    private bool rightMove = true;
    public bool activePatrol = true;

    public Transform groundDetector;
    private Transform player;
    public GameObject shot;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.queriesStartInColliders = false;

    }

    // Update is called once per frame
    void Update()
    {

        //Patroling:
       if(activePatrol) transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (rightMove == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                rightMove = false;
                facingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rightMove = true;
                facingRight = true;
            }
        }

        // when the player is nearby:
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            activePatrol = false;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            activePatrol = false;
            transform.position = new Vector2(Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime).x, transform.position.y);

            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + fireRate;
                Attack();
            }
        }
       

    }

    void Attack()
    {
        AttackPos = transform.position;
        if (facingRight)
        {
            AttackPos += new Vector2(0.1f, 0.15f);
            Instantiate(AttackRight, AttackPos, Quaternion.identity);
        }
        else
        {
            AttackPos += new Vector2(-0.1f, 0.15f);
            Instantiate(AttackLeft, AttackPos, Quaternion.identity);
        }
    }
}