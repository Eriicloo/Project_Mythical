using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_and_Damage : MonoBehaviour
{
    public float life = 80.0f;
    public float maxLife = 100.0f;
    public bool invencible = false;
    public float invencible_time = 0.5f;
    public float braking_time = 0.1f;

    Patrol patrol;

    public void Subtract_life(float amount)
    {
        if (!invencible && life > 0)
        {
            life -= amount;
            StartCoroutine(invulnerability());
        }
        if (life <= 1)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator invulnerability()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
    }
}
