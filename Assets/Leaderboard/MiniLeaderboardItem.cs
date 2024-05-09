using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniLeaderboardItem : MonoBehaviour
{
    [SerializeField] string rank;
    [SerializeField] TextMeshProUGUI textScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarDatos(string score)
    {
        
        textScore.text = rank+" "+score;
    }
}
