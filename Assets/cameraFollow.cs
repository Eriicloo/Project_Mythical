using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject follow;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;

    public int musicPlaying;
    private bool musicStart;

    private Vector2 velocity;

    void Start()
    {
    }

    //Utilitzem el fixed update perque les fisiques es puguin fer cada segon en comptes de cada frame. Aixi no donarà problemes
    //depenent de la calitat del ordinador
    void FixedUpdate()
    {
        //Emprem el SmoothDamp, que es una funció de la llibrería Mathf, la cual fara que la camara segueixi el character
        //de forma que vaigue una mica retrasada, fent el moviment mes llisa, agradable
        float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(  
        Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), 
        Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), 
        transform.position.z);

        if (!musicStart) 
        {
            musicStart = true;
            AudioManager.instance.PlayBgm(musicPlaying);
        }

    }
}
