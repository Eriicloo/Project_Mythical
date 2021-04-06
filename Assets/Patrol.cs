using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance = 2f;
    public float stopDistance;
    public float retreatDistance;

    private float timeShots;
    public float startTimeShots;

    private bool rightMove = true;

    public Transform groundDetector;

    private Transform player;
    public GameObject shot;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeShots = startTimeShots;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, player.position) > stopDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }


        

        if (timeShots <= 0) {
            Instantiate(shot, transform.position, Quaternion.identity);
            timeShots = startTimeShots;
        }
        else {
            timeShots -= Time.deltaTime;        
        }




        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, distance);
        if (groundInfo.collider == false) {
            if (rightMove == true) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                rightMove = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                rightMove = true;
            }
        }
    }
}
