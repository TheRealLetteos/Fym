using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class MixerSettings
{
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;
}

public class MixerSettingsManager : MonoBehaviour
{
    public MixerSettings mixerSettings;

    private string settingsPath;

    private void Awake()
    {
        settingsPath = Application.persistentDataPath + "/mixer_settings.json";
    }

    public void SaveSettings(string mixerName, float value)
    {
        Debug.Log(mixerName);
        if (mixerName == "MasterVolume")
        {
            mixerSettings.masterVolume = value;
            Debug.Log(mixerSettings.masterVolume);
        }
        else if (mixerName == "MusicVolume")
        {
            mixerSettings.musicVolume = value;
            Debug.Log(mixerSettings.masterVolume);
        }
        else if (mixerName == "SFXVolume")
        {
            mixerSettings.sfxVolume = value;
            Debug.Log(mixerSettings.masterVolume);
        }
        string json = JsonUtility.ToJson(mixerSettings);
        File.WriteAllText(settingsPath, json);
    }

    public void LoadSettings()
    {
        if (File.Exists(settingsPath))
        {
            string json = File.ReadAllText(settingsPath);
            mixerSettings = JsonUtility.FromJson<MixerSettings>(json);
        }
        else
        {
            Debug.LogWarning("No settings file found.");
        }
    }
}


