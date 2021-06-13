using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBoss: MonoBehaviour
{
    public int clearedLevels = 0;
    public GameObject barra;
    public string key1 = "Level4";
    public string key2 = "Level2";
    public string key3 = "Level3";

    private void Start()
    {
        if (PlayerPrefs.GetInt(key1, 0) == 1)
            clearedLevels++;

        if (PlayerPrefs.GetInt(key2, 0) == 1)
            clearedLevels++;

        if (PlayerPrefs.GetInt(key3, 0) == 1)
            clearedLevels++;

        if (clearedLevels == 3)
        {
            Destroy(barra);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }
}