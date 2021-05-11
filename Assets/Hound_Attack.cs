﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_Attack : MonoBehaviour
{

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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health_and_Damage>().Subtract_life(amount);
        }
    }
}