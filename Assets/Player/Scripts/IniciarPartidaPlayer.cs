using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarPartidaPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Movimiento movimiento;
    [SerializeField] float GravityScaleAnimacion = 1;
    [SerializeField] IniciarMapa managerPartidaMapa;
    [SerializeField] IniciarPacman managerPartidaPacman;
    float gravityScaleOriginal;
    [SerializeField] Cronometro cronometro;
    // Start is called before the first frame update
    void Start()
    {
        rb.WakeUp();
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
            cronometro.Iniciar();
            managerPartidaPacman.enabled = true;
            managerPartidaMapa.Iniciar();
        }
    }

    
}
