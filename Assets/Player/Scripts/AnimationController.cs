using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 speed = rb.velocity;
        if (speed.y != 0)
        {
            animator.SetBool("Idel", false);
            animator.SetBool("Caminando", false);
            animator.SetBool("Saltando", true);
        }
            
        else if (speed.x != 0)
        {
            animator.SetBool("Idel", false);
            animator.SetBool("Caminando", true);
            animator.SetBool("Saltando", false);
        }
            
        else
        {
            animator.SetBool("Idel", true);
            animator.SetBool("Caminando", false);
            animator.SetBool("Saltando", false);
        }
            
    }
}
