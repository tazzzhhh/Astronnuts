using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SPXSource;

    [Header("----- Audio Clip -----")]
    public AudioClip death;
    public AudioClip background;
    public AudioClip collection;
    public AudioClip finish;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void PlaySFX(AudioClip clip)
    {
        SPXSource.PlayOneShot(clip);
    }

    public void StopBackgroundMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
