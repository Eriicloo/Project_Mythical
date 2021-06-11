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
        GameObject bgm = GameObject.Find("TitleSong");
        if (bgm)
        {
            musicplayer = bgm.GetComponent<MusicPlayer>();
            if (musicplayer) 
            {
                GetComponent<Slider>().onValueChanged.AddListener(musicplayer.updateVolume);
            }
        }

        GameObject bgm2 = GameObject.Find("lvl1Song");
        if (bgm2)
        {
            musicplayer = bgm2.GetComponent<MusicPlayer>();
            if (musicplayer)
            {
                GetComponent<Slider>().onValueChanged.AddListener(musicplayer.updateVolume);
            }
        }

        GameObject bgm3 = GameObject.Find("lvl2Song");
        if (bgm3)
        {
            musicplayer = bgm3.GetComponent<MusicPlayer>();
            if (musicplayer)
            {
                GetComponent<Slider>().onValueChanged.AddListener(musicplayer.updateVolume);
            }
        }
    }
}