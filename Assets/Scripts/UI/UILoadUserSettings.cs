using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class UILoadUserSettings : MonoBehaviour
{
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Toggle musicToggle;

    private void Awake()
    {
        if (ES3.KeyExists(UserDataKeys.SFX_SETTING))
        {
            sfxToggle.isOn = ES3.Load<bool>(UserDataKeys.SFX_SETTING);
        }
        if (ES3.KeyExists(UserDataKeys.MUSIC_SETTING))
        {
            musicToggle.isOn = ES3.Load<bool>(UserDataKeys.MUSIC_SETTING);
        }
    }
}
