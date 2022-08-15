using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
        
        if (ES3.KeyExists(UserDataKeys.SFX_SETTING))
        {
            isSFXEnabled = ES3.Load<bool>(UserDataKeys.SFX_SETTING);
        }

        if (ES3.KeyExists(UserDataKeys.MUSIC_SETTING))
        {
            isMusicEnabled = ES3.Load<bool>(UserDataKeys.MUSIC_SETTING);
        }
    }

    #endregion
    
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool isSFXEnabled;
    [SerializeField] private bool isMusicEnabled;
    

    private void Start()
    {
        if (isMusicEnabled)
        {
            StartCoroutine(LoopBackgroundMusic());
        }
    }

    public void PlaySound(AudioClip sound)
    {
        if (isSFXEnabled)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    public void EnableMusic(bool toEnable)
    {
        isMusicEnabled = toEnable;
        
        if (toEnable)
        {
            StartCoroutine(LoopBackgroundMusic());
        }
        else
        {
            StopAllCoroutines();
            audioSource.Stop();
        }
    }

    public void EnableSFX(bool toEnable)
    {
        isSFXEnabled = toEnable;
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

    private void SaveSettings()
    {
        ES3.Save<bool>(UserDataKeys.SFX_SETTING, isSFXEnabled);
        ES3.Save<bool>(UserDataKeys.MUSIC_SETTING, isMusicEnabled);
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        SaveSettings();
    }

    private void OnApplicationQuit()
    {
        SaveSettings();
    }
}
