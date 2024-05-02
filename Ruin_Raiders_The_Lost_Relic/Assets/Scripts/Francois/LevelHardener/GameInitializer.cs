using UnityEngine;

public class GameInitializer : MonoBehaviour
{
 
    public GameObject player;
    public GameObject inputHandler;


    public void ActivateGameObjects()
    {
        if (player != null)
            player.SetActive(true);
        if (inputHandler != null)
            inputHandler.SetActive(true);
    }

   
  

    
    //void Start()
    //{
    //    ActivateGameObjects(); 
    //}
}