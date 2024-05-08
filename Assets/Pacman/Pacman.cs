using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float maxSpeed;
    [SerializeField] Transform player;
    [SerializeField] float aceleracion = 1f;
    bool congelado;
    [SerializeField]float duracionCongelacion;
    bool detenidoPermanente;
    float maxAceleracion;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] Sprite spriteMuerto;
    private void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detenidoPermanente)
            return;
        if(congelado)         
            return;
        rb.AddForce(new Vector2(0, aceleracion));
        maxAceleracion = Mathf.Max(aceleracion, rb.velocity.y);
        if (rb.velocity.y > maxSpeed)
            rb.velocity = new Vector2(0, maxSpeed);
    }

    public void Congelar()
    {
        spriteRenderer.color = Color.cyan;
        animator.enabled = false;
        CancelInvoke("Descongelarse");
        aceleracion = maxAceleracion;//Hacemos que retorne con su misma speed que tenia antes ya
        rb.velocity = Vector2.zero;
        
        congelado = true;
        Invoke("Descongelarse", duracionCongelacion);
    }

    void Descongelarse()
    {
        animator.enabled = true;
        spriteRenderer.color = Color.white;
        congelado = false;
    }   
    
    public void DetenerPermanente()
    {
        spriteRenderer.color = Color.cyan;
        animator.enabled = false;
        detenidoPermanente = true;
        spriteRenderer.sprite = spriteMuerto;
        rb.velocity = Vector2.zero;
    }
}
