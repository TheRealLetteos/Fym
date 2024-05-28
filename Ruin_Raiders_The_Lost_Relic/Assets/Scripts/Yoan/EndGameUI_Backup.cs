using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _restartUI;
    [SerializeField] private GameObject _player;
    private Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _restartUI.SetActive(true);
            _player.SetActive(false);
        }
    }


    public void restart()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
