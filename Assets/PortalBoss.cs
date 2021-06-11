using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBoss: MonoBehaviour
{
    public int clearedLevels = 0;
    public GameObject barra;
    private void Start()
    {
        if(clearedLevels == 1)
        {
            Destroy(barra);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && clearedLevels == 1)
        {
            SceneManager.LoadScene(3);
        }
    }
}