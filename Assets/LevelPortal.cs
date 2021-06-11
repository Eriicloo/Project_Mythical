using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    public int scene;
    public PortalBoss boss;
    public string key = "Level1";
    private void Start()
    {
        if(PlayerPrefs.GetInt(key, 0) == 1)
        {
            boss.clearedLevels++;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene);
            boss.clearedLevels++;
        }
    }
}
