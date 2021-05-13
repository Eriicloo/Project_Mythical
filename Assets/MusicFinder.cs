using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicFinder : MonoBehaviour
{
    MusicPlayer musicplayer = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bgm = GameObject.Find("Background Audio");
        if (bgm) 
        {
            musicplayer = bgm.GetComponent<MusicPlayer>();
            if (musicplayer) 
            {
                GetComponent<Slider>().onValueChanged.AddListener(musicplayer.updateVolume);
            }
        }
    }
}