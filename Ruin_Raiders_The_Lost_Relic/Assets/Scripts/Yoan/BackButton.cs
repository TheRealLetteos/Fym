using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject _restartUI;
    
    private Scene scene;
    
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    
    public void restart()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
