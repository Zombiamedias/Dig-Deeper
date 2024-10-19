using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SettingsMenuManager : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown; // Texto en pantalla en el Dropdown menu para la calidad
    public Slider masterVol, musicVol, SFXVol; // Sliders de audio
    public AudioMixer audioMixer; // Referencia al audio mixer
    private void Start()
    {
        // Empezar al máximo volumen (1 equivale a 0 dBFS)
        masterVol.value = 1.0f;
        musicVol.value = 1.0f;
        SFXVol.value = 1.0f;
    }
    public void ChangeGraphicQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value); // Ajusta la calidad gráfica según el valor del Dropdown
    }
    public void ChangeMasterVolume()
    {
        SetVolume("masterVol", masterVol.value); // Aplica la conversión lineal a logarítmica para el volumen
    }
    public void ChangeMusicVolume()
    {
        SetVolume("musicVol", musicVol.value); // Aplica la conversión lineal a logarítmica para la música
    }
    public void ChangeSFXVolume()
    {
        SetVolume("SFXVol", SFXVol.value); // Aplica la conversión lineal a logarítmica para los efectos de sonido
    }
    private void SetVolume(string parameterName, float sliderValue)
    {
        // Convertir el valor lineal (0 a 1) a decibelios (dB)
        float dB;
        if (sliderValue > 0)
        {
            dB = Mathf.Log10(sliderValue) * 20; // Convertir lineal a logarítmico
        }
        else
        {
            dB = -80f; // Si el valor es 0, establecer en -80dB (casi silencio total)
        }
        audioMixer.SetFloat(parameterName, dB); // Ajusta el volumen en el AudioMixer
    }
}