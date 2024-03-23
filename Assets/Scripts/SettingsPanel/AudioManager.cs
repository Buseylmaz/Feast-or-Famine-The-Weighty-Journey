using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("StartMusic"); //baþlangýç muzik
    }

    public void PlayMusic(string name)
    {

        Sounds s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.audioClip;
            musicSource.Play();
        }
    }


    public void PlaySFX(string name)
    {
        Sounds s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.audioClip);
        }
    }


    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }


    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
