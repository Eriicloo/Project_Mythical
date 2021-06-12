using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TransitionSum : MonoBehaviour
{
    public string key = "Level1";
    public int scene;
    public PortalBoss boss;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene);
            PlayerPrefs.SetInt(key, 1);
            boss.clearedLevels++;
        }
    }
}
