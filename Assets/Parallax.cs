using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject cam;
    public Vector3 lastCameraPosition;
    public Vector2 parallaxEffect;
    public float textureUnitSizeX;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
        lastCameraPosition = cam.transform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cam.transform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect.x / 10, deltaMovement.y * parallaxEffect.y / 10, 0);
        lastCameraPosition = cam.transform.position;

        if (Mathf.Abs(cam.transform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cam.transform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cam.transform.position.x + offsetPositionX, transform.position.y);
        }
    }
}