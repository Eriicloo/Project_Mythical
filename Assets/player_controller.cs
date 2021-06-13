using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 7f;
    public float cd = 1f;

    private float nextDashTime = 0f;
    bool facingRight = true;

    public bool isTouching = false;
    public bool wallJumpLeft;
    public bool wallJumpRight;
    public bool wallSliding;
    public float wallSlidingSpeed = 0.75f;
    public float wallJumpCD = 0.20f;

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
    public bool movement = true;
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
            if (wallJumpLeft)
            {
                jump = true;
            }
            if (wallJumpRight)
            {
                jump = true;
            }

            

            if (grounded)
            {
                jump = true;
                doubleJump = true;
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

        if (Input.GetKey(KeyCode.Q) || Input.GetButton("Glide"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -1f);
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

        if (isTouching && grounded == false)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (wallJumpLeft && jump)
        {
            rb2d.velocity = new Vector2(15, 20);
            doubleJump = true;
        }

        if (wallJumpRight && jump)
        {
            rb2d.velocity = new Vector2(-15, 20);
            doubleJump = true;
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

        if (!movement)
            movX = 0;

        if (movement)
        {
            rb2d.AddForce(Vector2.right * speed * movX);
        }

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (movX > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            facingRight = true;
        }

        if (movX < -0.1f)
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
        transform.position = new Vector3(0, 0, 0);
    }

    public void ActivateMovement()
    {
        movement = true;
    }
    public void DeactivateMovement()
    {
        movement = false;
    }

    void EnemyKnockBack(float enemyPosX)
    {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.right * side, ForceMode2D.Impulse);

        Invoke("ChangeColor", 0.3f);

        spr.color = Color.red;
    }

    void ChangeColor() {
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
        if (collision.gameObject.tag == "WallJumpingLeft")
        {
            movement = false;
            isTouching = true;
            wallJumpLeft = true;
        }
        if (collision.gameObject.tag == "WallJumpingRight")
        {
            movement = false;
            isTouching = true;
            wallJumpRight = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WallJumpingLeft")
        {
            isTouching = false;
            wallJumpLeft = false;
            StartCoroutine(EnableMovement());
        }
        if (collision.gameObject.tag == "WallJumpingRight")
        {
            isTouching = false;
            wallJumpRight = false;
            StartCoroutine(EnableMovement());  
        }
    }

    IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(wallJumpCD);
        movement = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            transform.position = new Vector3(0, 0, 0);
        }

        if (collision.CompareTag("Saw"))
        {
            transform.position = new Vector3(0, 0, 0);
        }

        if (collision.CompareTag("Water"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
