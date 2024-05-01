using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarPacman : MonoBehaviour
{
    float time = 0;
    [SerializeField] float cdAparecerPacman;
    bool pacmanInvocado;
    [SerializeField] Pacman pacman;

    

    private void Update()
    {
        if (pacmanInvocado)
            return;
        if(time < cdAparecerPacman)
        {
            time += Time.deltaTime;
        }

        else
        {
            pacmanInvocado = true;
            pacman.enabled = true;
        }
    }

}
