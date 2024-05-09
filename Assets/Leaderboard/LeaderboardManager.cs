using UnityEngine;
using TMPro;

// NOTE: Make sure to include the following namespace wherever you want to access Leaderboard Creator methods
using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private LeaderboardItem[] leaderboardItems;
        [SerializeField] private TMP_InputField _usernameInputField;
        [SerializeField] GameObject ingresarPlayer;
        [SerializeField] int maxCantidadRecords;
        [SerializeField] PantallaVictoria pantallaVictoria;
        // Make changes to this section according to how you're storing the player's score:
        // ------------------------------------------------------------
        [SerializeField] private PuntuacionPlayer puntuacionPlayer;
        bool bloqueadoAgregarRecord = true;
        // ------------------------------------------------------------

        private void Start()
        {
            LoadEntries();
        }

        private void LoadEntries()
        {
            // Q: How do I reference my own leaderboard?
            // A: Leaderboards.<NameOfTheLeaderboard>

            Leaderboards.JuegoPacman.GetEntries(entries =>
            {
                
                var length = Mathf.Min(leaderboardItems.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    leaderboardItems[i].CargarDatos(entries[i].Username, entries[i].Extra);
                if (bloqueadoAgregarRecord == true)
                    return;
                if(length >= maxCantidadRecords)
                {
                    
                    ValidarPlayerSuperoPuntuacion(entries[length - 1].Rank, entries[length - 1].Extra);
                }
                    
                else
                {
                    ingresarPlayer.SetActive(true);
                }
                    
            });
            
        }

        public void ValidarPlayerSuperoPuntuacion(int Rank, string tiempo)
        {
            
            float recordPlayer = float.Parse(puntuacionPlayer.GetTimeRecordInString());
            float recordFinalTabla = float.Parse(tiempo);
            if (recordPlayer < recordFinalTabla)//Mientras mas bajo mejor en esta tabla por ser tiempos
            {
                ingresarPlayer.SetActive(true);
            }

            else
                pantallaVictoria.Reiniciar();
        }

        public void UploadEntry()
        {
            FixName();
            Leaderboards.JuegoPacman.ResetPlayer();
            Leaderboards.JuegoPacman.UploadNewEntry(_usernameInputField.text, puntuacionPlayer.GetTimeRecordInScore(), puntuacionPlayer.GetTimeRecordInString(), isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
        }

        public void Bloquear()
        {
            bloqueadoAgregarRecord = true;
        }
        public void Desbloquear()
        {
            bloqueadoAgregarRecord = false;
        }

        public void FixName()
        {
            if (_usernameInputField.text == "")
                _usernameInputField.text = "DefaultName";
        }
    }
}