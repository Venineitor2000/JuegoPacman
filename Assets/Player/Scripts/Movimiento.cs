using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float speedSalto;
    [SerializeField] LayerMask capaSuelo;
    float tiempoEnElAire;
    [SerializeField] float coyoteTimeduration;
    [SerializeField] float fallSpeed;
    [SerializeField] float jumpEarlyModifier;
    bool endedJumpEarly;
    bool bufferPendingJump;
    [SerializeField] float coldownBuffer;
    float startBuffer;
    bool detenidoPermanente;
    [SerializeField] SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (detenidoPermanente)
            return;
            rb.velocity = new Vector2(GetHorizotalSpeed(), GetVerticalFallSpeed());
        
            

    }

    private void Update()
    {

        RotarSprite();
        if (detenidoPermanente)
            return;
        ActualizarContadorTiempoEnELAire();


        if (ComprobarSuelo() && bufferPendingJump && startBuffer + coldownBuffer > Time.time)
            Saltar();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bufferPendingJump = true;
            startBuffer = Time.time;
            endedJumpEarly = false;
            if (ComprobarSuelo())
            {
                Saltar();

            }
            else
            {
                bool canJumpCoyoteTime = tiempoEnElAire < coyoteTimeduration;
                if (canJumpCoyoteTime)
                {
                    Saltar();
                }

            }
            

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            endedJumpEarly = true;
            tiempoEnElAire = coyoteTimeduration + 1;
        }
            

    }

    void ActualizarContadorTiempoEnELAire()
    {
        if (ComprobarSuelo())
        {
            tiempoEnElAire = 0;

        }
        else
        {
            tiempoEnElAire += Time.deltaTime;
        }
    }

    float GetVerticalFallSpeed()
    {

        float verticalSpeed = rb.velocity.y;

        if(endedJumpEarly)        
            verticalSpeed -= fallSpeed * jumpEarlyModifier *Time.fixedDeltaTime;
            
        
        else
            verticalSpeed = rb.velocity.y;

        if (rb.velocity.y < -fallSpeed) 
            verticalSpeed = -fallSpeed;
        

        return verticalSpeed;
    }
    float GetHorizotalSpeed()
    {
        float horizontalSpeed;
        if (Input.GetAxisRaw("Horizontal") != 0)
            horizontalSpeed = Input.GetAxis("Horizontal") * speed;
        else
            horizontalSpeed = 0;
        return horizontalSpeed;
    }

    bool ComprobarSuelo()
    {
        float distanciaDesdeElCentroALosBordes = 0.17f; //La distancia que hay desde el centro del player hasta los bordes del sprite, para calcular los raycast
        float distanciaRaycast = 0.35f;
        RaycastHit2D raycastSuelo1 =  Physics2D.Raycast(transform.position, Vector2.down, distanciaRaycast, capaSuelo);
        RaycastHit2D raycastSuelo2 = Physics2D.Raycast(transform.position + new Vector3(distanciaDesdeElCentroALosBordes,0,0), Vector2.down, distanciaRaycast, capaSuelo);
        RaycastHit2D raycastSuel3 = Physics2D.Raycast(transform.position + new Vector3(-distanciaDesdeElCentroALosBordes, 0, 0), Vector2.down, distanciaRaycast, capaSuelo);

        return raycastSuelo1 || raycastSuelo2 || raycastSuel3;
    }

    void Saltar()
    {
        CorregirPosicionPlayerAlChocarEsquina();
        bufferPendingJump = false;
        rb.velocity = new Vector2(rb.velocity.y, speedSalto);
    }

    void CorregirPosicionPlayerAlChocarEsquina()
    {
        float distanciaDesdeElCentroALosBordes = 0.17f; //La distancia que hay desde el centro del player hasta los bordes del sprite, para calcular los raycast
        float distanciaRaycast = 2f;
        float correccionPosicionX = 0.1f;
        RaycastHit2D raycastSuelo2 = Physics2D.Raycast(transform.position + new Vector3(distanciaDesdeElCentroALosBordes,0,0), Vector2.up, distanciaRaycast, capaSuelo);
        RaycastHit2D raycastSuel3 = Physics2D.Raycast(transform.position + new Vector3(-distanciaDesdeElCentroALosBordes, 0, 0), Vector2.up, distanciaRaycast, capaSuelo);
        if (raycastSuelo2 && !raycastSuel3)
            transform.position -= new Vector3(correccionPosicionX, 0, 0);
        else if(!raycastSuelo2 && raycastSuel3)
            transform.position += new Vector3(correccionPosicionX, 0, 0);
    }

    public void DetenerPermanente()
    {
        rb.velocity = Vector3.zero;
        detenidoPermanente = true;
    }

    void RotarSprite()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0)
        {
            sprite.flipX = false; // No voltear
        }
        else if (moveInput < 0)
        {
            sprite.flipX = true; // Voltear horizontalmente
        }
    }
}
