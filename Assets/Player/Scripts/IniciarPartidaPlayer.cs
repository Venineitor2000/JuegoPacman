using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarPartidaPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Movimiento movimiento;
    [SerializeField] float GravityScaleAnimacion = 1;
    [SerializeField] IniciarMapa managerPartida;
    float gravityScaleOriginal;
    // Start is called before the first frame update
    void Start()
    {
        
        gravityScaleOriginal = rb.gravityScale;
        rb.gravityScale = GravityScaleAnimacion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TriggerIniciarPartida"))
        {
            rb.gravityScale = gravityScaleOriginal;
            movimiento.enabled = true;
            managerPartida.Iniciar();
        }
    }

    
}
