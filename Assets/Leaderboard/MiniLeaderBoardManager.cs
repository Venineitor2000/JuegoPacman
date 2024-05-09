using UnityEngine;
using TMPro;

// NOTE: Make sure to include the following namespace wherever you want to access Leaderboard Creator methods
using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class MiniLeaderBoardManager : MonoBehaviour
    {
        [SerializeField] private MiniLeaderboardItem[] leaderboardItems;
        // Make changes to this section according to how you're storing the player's score:
        // ------------------------------------------------------------
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
                    leaderboardItems[i].CargarDatos(entries[i].Extra);
            });

        }

        

        

        

       
    }
}