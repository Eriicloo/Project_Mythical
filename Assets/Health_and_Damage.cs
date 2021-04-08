using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_and_Damage : MonoBehaviour
{
    public float life = 50.0f;
    public bool invencible = false;
    public float invencible_time = 0.5f;
    public float braking_time = 0.1f;

    public void Subtract_life(float amount)
    {
        if (!invencible && life > 0)
        {
            life -= amount;
            StartCoroutine(invulnerability());
        }
    }

    IEnumerator invulnerability()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
    }
}
