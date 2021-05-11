﻿using UnityEngine;
using UnityEngine.Audio;
using System;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    private float musicvolume = 1f;

    public static MusicPlayer instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicvolume;
    }

    public void updateVolume(float volume) 
    {
        musicvolume = volume;
    }

}