using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health_and_Damage : MonoBehaviour
{
    public float life = 80.0f;
    public float maxLife = 100.0f;
    public bool invencible = false;
    public float invencible_time = 0.5f;
    public float braking_time = 0.1f;



    Patrol patrol;
    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    public void Subtract_life(float amount)
    {
        if (!invencible && life > 0)
        {
            life -= amount;
        }
        if (life <= 1)
        {
            Destroy(gameObject);
        }
        Invoke("ChangeColor", 0.7f);

        spr.color = Color.red;

    }
    public void Subtract_life_player(float amount)
    {
        if (!invencible && life > 0)
        {
            life -= amount;
            StartCoroutine(invulnerability());
        }
        if (life <= 1)
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }

    }
    public void Subtract_life_boss(float amount)
    {
        if (!invencible && life > 0)
        {
            life -= amount;
        }
        if (life <= 1)
        {
            SceneManager.LoadScene("Win");
            Destroy(gameObject);
        }
        Invoke("ChangeColor", 0.7f);

        spr.color = Color.red;
    }

    void ChangeColor()
    {
        spr.color = Color.white;
    }

    IEnumerator invulnerability()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
    }
}
