using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource[] bgm;

    public static AudioManager instance;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) 
        { 
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    public void PlayBgm(int musicPlaying) 
    {
        if (!bgm[musicPlaying].isPlaying) 
        {
            StopMusic();
            
            if(musicPlaying < bgm.Length)
                bgm[musicPlaying].Play();
        }
    }

    public void StopMusic() 
    {
        for (int i = 0; i < bgm.Length; i++)
            bgm[i].Stop();
    }
}
