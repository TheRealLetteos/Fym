using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


namespace fym
{
    public class OptionMenuController : MonoBehaviour
    {

        private UIDocument optionMenuDocument;

        private Slider volumeSlider;

        private Slider musicSlider;

        private Slider sfxSlider;

        private EnumField resolutionField;

        private Button backButton;

        private void Awake()
        {
            optionMenuDocument = GetComponent<UIDocument>();
            volumeSlider = optionMenuDocument.rootVisualElement.Q<Slider>("VolumeSlider");
            volumeSlider.RegisterValueChangedCallback((evt) => OnVolumeChange(evt.newValue));
            musicSlider = optionMenuDocument.rootVisualElement.Q<Slider>("MusicSlider");
            musicSlider.RegisterValueChangedCallback((evt) => OnMusicChange(evt.newValue));
            sfxSlider = optionMenuDocument.rootVisualElement.Q<Slider>("SoundFxSlider");
            sfxSlider.RegisterValueChangedCallback((evt) => OnSoundFxChange(evt.newValue));
            backButton = optionMenuDocument.rootVisualElement.Q<Button>("BackButton");
            backButton.clicked += () => OnBackClick();
            resolutionField = optionMenuDocument.rootVisualElement.Q<EnumField>("ResolutionEnumField");
            resolutionField.Init(ResolutionType._1920x1080);
            resolutionField.RegisterValueChangedCallback((evt) => OnResolutionChange(evt.newValue));
        }

        public void DeactivateMenu()
        {
            optionMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        }

        public void ActivateMenu()
        {
            optionMenuDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        }

        private void OnResolutionChange(Enum newValue)
        {
            throw new NotImplementedException();
        }

        private void OnSoundFxChange(float newValue)
        {
            throw new NotImplementedException();
        }

        private void OnMusicChange(float newValue)
        {
            throw new NotImplementedException();
        }

        private void OnVolumeChange(float newValue)
        {
            throw new NotImplementedException();
        }

        private void OnBackClick()
        {
            Debug.Log("Back to main menu");
            MenuSystem.Instance.LoadMainMenu();
        }

    }
}