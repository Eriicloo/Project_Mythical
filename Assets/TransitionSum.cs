using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TransitionSum : MonoBehaviour
{
    public string key = "Level1";

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt(key, 1);
        }
    }
}
