using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    private BoxCollider2D cubeCollider;
    [SerializeField] private GameObject _key;
    [SerializeField] private BoxCollider2D _keyCollider;
    [SerializeField] private Rigidbody2D _keyRb;

    void Start()
    {
        // Récupérer le composant BoxCollider2D attaché au cube
        cubeCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifier si la collision est avec un autre cube
        if (collision.gameObject.CompareTag("Key"))
        {
            // Désactiver le collider du cube
            _key.transform.position = this.transform.position;
            cubeCollider.enabled = false;
            _keyRb.bodyType = RigidbodyType2D.Static;
            _keyCollider.enabled = false;
            
            // Rendre le cube statique pour qu'il reste à sa position
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
