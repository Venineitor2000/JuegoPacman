using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaVictoria : MonoBehaviour
{
    [SerializeField]float delay = 5f;
    [SerializeField] ManagerFinPartida managerFinPartida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        Invoke("AbrirEscena", delay);
    }

    void AbrirEscena()
    {
        if(managerFinPartida != null) 
        managerFinPartida.ReiniciarJuego();
    }


    
}
