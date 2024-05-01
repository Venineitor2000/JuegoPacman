using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Morir : MonoBehaviour
{
    [SerializeField] Movimiento movimiento;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    public UnityEvent OnPlayerDie = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pacman"))
        {
            movimiento.enabled = false;
            sprite.flipY = true;
            boxCollider.enabled = false;
            rb.gravityScale = 0;
            rb.Sleep();
            animator.enabled = true; //Despues cuando haya mas animaciones ya lo tendriamos activo siempre y cambiariamos sus estados
            OnPlayerDie?.Invoke();
            
        }
    }

    
}
