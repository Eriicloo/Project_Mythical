using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
   public player_controller player;

    public void FinishCinematic()
    {
        player.movement = true;
        gameObject.SetActive(false);
    }
}
