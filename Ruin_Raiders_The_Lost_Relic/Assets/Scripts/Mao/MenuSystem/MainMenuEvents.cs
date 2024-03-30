using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument uiDocument;

    private Button startButton;

    private Button quitButton;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        startButton = uiDocument.rootVisualElement.Q<Button>("StartButton");
        startButton.RegisterCallback<ClickEvent>(OnStartGameClick);
        quitButton = uiDocument.rootVisualElement.Q<Button>("QuitButton");
        quitButton.RegisterCallback<ClickEvent>(OnQuitGameClick);
    }

    private void OnQuitGameClick(ClickEvent evt)
    {
        Debug.Log("Quit Game Clicked");
        Application.Quit();
    }

    private void OnStartGameClick(ClickEvent evt)
    {
        Debug.Log("Start Game Clicked");
        SceneManager.UnloadSceneAsync("LobbyScene");
        SceneManager.LoadScene("SampleScene");
    }
}
