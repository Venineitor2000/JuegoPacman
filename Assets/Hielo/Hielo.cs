using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hielo : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] GameObject sprite;
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
            sprite.SetActive(false);
            audioSource.Play();
            boxCollider.enabled = false;
            Invoke("DestroyHelado", 1f);
        }
    }

    void DestroyHelado()
    {
        Destroy(gameObject);
    }
}
