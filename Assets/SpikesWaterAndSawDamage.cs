using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesWaterAndSawDamage : MonoBehaviour
{

    public float spikeDamage = 15.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health_and_Damage>().Subtract_life_player(spikeDamage);
            
        }
    }
}
