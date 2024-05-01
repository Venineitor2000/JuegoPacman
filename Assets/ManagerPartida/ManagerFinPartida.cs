using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerFinPartida : MonoBehaviour
{
    [SerializeField] float delayTrasMuertePlayer;
    [SerializeField] GameObject cartelDerrota, cartelVictoria;
    [SerializeField] Pacman pacman;
    [SerializeField] Movimiento player;
    public void FinalizarPartidaPorMuerte()
    {
        cartelDerrota.SetActive(true);
        Invoke("ReiniciarJuego", delayTrasMuertePlayer);
    }

    public void FinalizarPartidaPorVictoria()
    {
        Time.timeScale = 0;
        pacman.DetenerPermanente();
        player.DetenerPermanente();
        cartelVictoria.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
