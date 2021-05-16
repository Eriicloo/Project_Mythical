using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Lever : MonoBehaviour
{

    public UnityEvent action;

    player_controller activate;
    public Sprite spriteActivated;
    public bool reusable = false;
    bool hasBeenUsed;
    public void ActivateLever()
    {
        Destroy(gameObject);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!reusable && hasBeenUsed)
            return;
        if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Action") && collision.CompareTag("Player"))
        {
            action.Invoke(); //Ejecutar una acción que yo le pongo en Unity
            GetComponent<SpriteRenderer>().sprite = spriteActivated;
            if (reusable)
                hasBeenUsed = true;
        }
    }


}
