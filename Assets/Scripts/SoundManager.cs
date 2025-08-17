using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioClip flapClip;
    public AudioClip hitClip;
    public AudioClip scoreClip;
    public AudioClip transitionClip;
    public AudioClip dieClip;


    private void Awake()
    {
        // Singleton pattern
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

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayFlap()
    {
        PlaySFX(flapClip);
    }

    public void PlayHit()
    {
        PlaySFX(hitClip);
    }

    public void PlayTransition()
    {
        PlaySFX(transitionClip);
    }

    public void PlayScore()
    {
        PlaySFX(scoreClip);
    }

    public void PlayDie()
    {
        PlaySFX(dieClip);
    }

    public void PlayMusic(AudioClip music)
    {

        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PauseMusic(bool value)
    {
        if (value)
            musicSource.Pause();
        else
            musicSource.UnPause();
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
