using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * drag this script to any gameobject you want to keep alive in all scenes
 */
namespace fym
{

    public class DontDestroyMe : MonoBehaviour
    {

        //public List<GameObject> DeactivateOnLoadList = new List<GameObject>();

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            /*foreach (GameObject go in DeactivateOnLoadList)
            {
                go.SetActive(false);
            }*/
        }

    }

}