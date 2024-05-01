using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hielo : MonoBehaviour
{
    static Pacman pacman;

    private void Start()
    {
        if(pacman == null) 
            pacman = GameObject.FindGameObjectWithTag("Pacman").GetComponent<Pacman>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            pacman.Congelar();
            Destroy(gameObject);
        }
    }
}
