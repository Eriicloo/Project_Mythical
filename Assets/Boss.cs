using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public int damage;
    public bool stageTwo = false;

    public Slider healthBar;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 50 && stageTwo == false)
        {
            anim.SetTrigger("stageTwo");
            stageTwo = true;
        }

        healthBar.value = health;
    }

    public void Prova() { 
    
    }
}