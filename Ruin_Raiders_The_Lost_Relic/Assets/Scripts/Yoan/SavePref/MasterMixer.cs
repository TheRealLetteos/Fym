using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;

public class MasterMixer : MonoBehaviour
{
    public MixerSettingsManager settingsManager;
    public AudioMixer audioMixer;
    private void Start()
    {
        settingsManager.LoadSettings();
        ApplySettings();
    }

    private void ApplySettings()
    {
        // Apply volumes to Master, Music, and SFX channels
        audioMixer.SetFloat("MasterVolume", settingsManager.mixerSettings.masterVolume);
        audioMixer.SetFloat("MusicVolume", settingsManager.mixerSettings.musicVolume);
        audioMixer.SetFloat("SFXVolume", settingsManager.mixerSettings.sfxVolume);
    }
}
