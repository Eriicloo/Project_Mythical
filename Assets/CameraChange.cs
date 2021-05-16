using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Transform cameraa;
    public float moveSpeed = 10f;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.position = new Vector3(cameraa.position.x,cameraa.position.y,cameraa.position.z);
        }
    }
}
