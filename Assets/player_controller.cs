using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public bool wall_jump;
    public float jumpPower = 7f;
    public int counterWallJump = 0;
    public float cd = 1f;
    private float nextDashTime = 0f;
    bool facingRight = true;


    public bool action;

    float movX;

    public float dashForce;
    public float startDashTime;
    float currentDashTime;
    float dashDirection;
    bool isDashing;



    public GameObject AttackLeft, AttackRight;
    Vector2 AttackPos;
    public float fireRate = 1f;
    float nextAttack = 0.0f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        movX = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (grounded)
        {
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Jump"))
        {
            if (wall_jump && counterWallJump < 4)
            {
                jump = true;

                if(jump)
                    counterWallJump++;
            }

            if (grounded)
            {
                jump = true;
                doubleJump = true;
                counterWallJump = 0;
            }
            else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }


        if(Input.GetButtonDown ("Fire1") && Time.time > nextAttack)
        {
            nextAttack = Time.time + fireRate;
            Attack();
        }

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetButton("Glide"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -1f);
        }
        if (Input.GetKey(KeyCode.E) || Input.GetButton("Action")) 
        {
            action = true;
        }

        if (Time.time > nextDashTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Dash") && movX != 0)
            {
                nextDashTime = Time.time + cd;
                isDashing = true;
                currentDashTime = startDashTime;
                rb2d.velocity = Vector2.zero;
                dashDirection = (int)movX;
            }
        }

    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }

        float h = Input.GetAxis("Horizontal");

        if (!movement) 
            h = 0;

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            facingRight = true;
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            facingRight = false;
        }

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        if (isDashing)
        {
            rb2d.AddForce(Vector2.right * dashForce * movX);

            currentDashTime -= Time.deltaTime;


            if (currentDashTime <= 0)
            {
                isDashing = false;
            }
        }


    }

    void OnBecameInvisible()
    {
        transform.position = new Vector3(-4, -1, 0);
    }


    void EnemyKnockBack(float enemyPosX)
    {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.right * side, ForceMode2D.Impulse);

        movement = false;
        Invoke("EnableMovement", 0.7f);

        spr.color = Color.red;
    }

    void EnableMovement() {
        movement = true;
        spr.color = Color.white;
    }

    void Attack() {
        AttackPos = transform.position;
        if (facingRight)
        {
            AttackPos += new Vector2(0.5f, 0f);
            Instantiate(AttackRight, AttackPos, Quaternion.identity);
        }
        else {
            AttackPos += new Vector2(-0.5f, 0f);
            Instantiate(AttackLeft, AttackPos, Quaternion.identity);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall_Jumping")
        {
            wall_jump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall_Jumping")
        {
            wall_jump = false;
        }
    }


    

    
}
