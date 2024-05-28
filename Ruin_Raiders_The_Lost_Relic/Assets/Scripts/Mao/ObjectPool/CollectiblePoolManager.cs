using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePoolManager : MonoBehaviour
{
    public static CollectiblePoolManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

}
