using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IniciarPartida : MonoBehaviour
{
    [SerializeField] IniciarPartidaPlayer player;
    [SerializeField] Button botonPlay;

    private void Start()
    {
        botonPlay.Select();
    }

    public void InciarPartida()
    {
        
        player.enabled = true;
        gameObject.SetActive(false);
    }
}
