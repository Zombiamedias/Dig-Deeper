using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenuManager : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider masterVol, musicVol, SFXVol;
    public AudioMixer audioMixer;
    public void ChangeGraphicQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }
    public void ChangeMasterVolume()
    {
        audioMixer.SetFloat("masterVol", masterVol.value);
    }
    public void ChangeMusicVolume()
    {
        audioMixer.SetFloat("musicVol", musicVol.value);
    }
    public void ChangeSFXVolume()
    {
        audioMixer.SetFloat("SFXVol", SFXVol.value);
    }
}
