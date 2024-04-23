using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Audio;


namespace fym
{
    public class OptionMenuController : AbstractMenuController
    {

        private Slider volumeSlider;

        private Slider musicSlider;

        private Slider sfxSlider;

        private EnumField resolutionField;

        private Button backButton;
        
        //Yoan
        [SerializeField]
        private AudioMixer mixer;

        private const string mixerMusic = "MusicVolume";

        private const string mixerSFX = "SFXVolume";

        private const string mixerMaster = "MasterVolume";
        
        private MixerSettingsManager settingsManager;

        private void Awake()
        {
            Initialize();
            volumeSlider = rootMenuDocument.rootVisualElement.Q<Slider>("VolumeSlider");
            volumeSlider.RegisterValueChangedCallback((evt) => OnVolumeChange(evt.newValue));
            musicSlider = rootMenuDocument.rootVisualElement.Q<Slider>("MusicSlider");
            musicSlider.RegisterValueChangedCallback((evt) => OnMusicChange(evt.newValue));
            sfxSlider = rootMenuDocument.rootVisualElement.Q<Slider>("SoundFxSlider");
            sfxSlider.RegisterValueChangedCallback((evt) => OnSoundFxChange(evt.newValue));
            backButton = rootMenuDocument.rootVisualElement.Q<Button>("BackButton");
            backButton.clicked += () => OnBackClick();
            resolutionField = rootMenuDocument.rootVisualElement.Q<EnumField>("ResolutionEnumField");
            resolutionField.Init(ResolutionType._1920x1080);
            resolutionField.RegisterValueChangedCallback((evt) => OnResolutionChange(evt.newValue));
            
            settingsManager = GetComponent<MixerSettingsManager>();
        }

        private void OnResolutionChange(Enum newValue)
        {
            //Yoan
            //Change the resolution of the screen
            ResolutionType selectedResolution = (ResolutionType)newValue;

            switch (selectedResolution)
            {
                case ResolutionType._854x480:
                    Screen.SetResolution(854, 480, true);
                    break;
                case ResolutionType._1280x720:
                    Screen.SetResolution(1280, 720, true);
                    break;
                case ResolutionType._1920x1080:
                    Screen.SetResolution(1920, 1080, true);
                    break;
                case ResolutionType._2560x1440:
                    Screen.SetResolution(2560, 1440, true);
                    break;
                default:
                    Debug.LogError("Unknown resolution type: " + selectedResolution);
                    break;
            }
        }

        private void OnSoundFxChange(float newValue)
        {
            //Yoan
            //Change the SFX Volume with the slider
            mixer.SetFloat(mixerSFX, newValue);
            settingsManager.SaveSettings(mixerSFX, newValue);
        }

        private void OnMusicChange(float newValue)
        {
            //Yoan
            //Change the Music Volume with the slider
            mixer.SetFloat(mixerMusic, newValue);
            settingsManager.SaveSettings(mixerMusic, newValue);
        }

        private void OnVolumeChange(float newValue)
        {
            //Yoan
            //Change the Master Volume with the slider
            mixer.SetFloat(mixerMaster, newValue);
            settingsManager.SaveSettings(mixerMaster, newValue);
        }

        private void OnBackClick()
        {
            Debug.Log("Back to main menu");
            MenuSystem.Instance.LoadMainMenu();
        }

    }
}