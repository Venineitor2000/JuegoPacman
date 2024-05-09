using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarPartida : MonoBehaviour
{
    [SerializeField] IniciarPartidaPlayer player;
    
    public void InciarPartida()
    {
        player.enabled = true;
        gameObject.SetActive(false);
    }
}
