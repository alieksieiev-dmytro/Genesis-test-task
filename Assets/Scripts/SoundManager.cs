using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool isEnabledSFX;
       
    
    private void Start()
    {
        StartCoroutine(LoopBackgroundMusic());
    }

    public void PlaySound(AudioClip sound)
    {
        if (isEnabledSFX)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    public void EnableMusic(bool toEnable)
    {
        if (toEnable)
        {
            StartCoroutine(LoopBackgroundMusic());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public void EnableSFX(bool toEnable)
    {
        isEnabledSFX = toEnable;
    }
    
    private IEnumerator LoopBackgroundMusic()
    {
        foreach (var clip in audioClips)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }

        StartCoroutine(LoopBackgroundMusic());
    }
}
