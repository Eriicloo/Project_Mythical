using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lever : MonoBehaviour
{

    player_controller activate;

    void ActivateLever()
    {
        activate.action = true;
        Destroy(gameObject);
    }


}
