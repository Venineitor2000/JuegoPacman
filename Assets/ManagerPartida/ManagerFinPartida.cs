using LeaderboardCreatorDemo;
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
    [SerializeField] PuntuacionPlayer puntuacionPlayer;
    [SerializeField] Cronometro cronometro;
    [SerializeField] LeaderboardManager leaderboardManager;
    [SerializeField] MiniLeaderBoardManager miniLeaderBoardManager;
    public void FinalizarPartidaPorMuerte()
    {
        cartelDerrota.SetActive(true);
        cronometro.Detener();
        Invoke("ReiniciarJuego", delayTrasMuertePlayer);
    }

    public void FinalizarPartidaPorVictoria()
    {
        Time.timeScale = 0;
        pacman.DetenerPermanente();
        player.DetenerPermanente();
        leaderboardManager.Desbloquear();
        cartelVictoria.SetActive(true);
        cronometro.Detener();
        miniLeaderBoardManager.gameObject.SetActive(false);
        ValidarRecordSuperado();
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void ValidarRecordSuperado()
    {
        puntuacionPlayer.UpdatePuntuacion();
    }
}
