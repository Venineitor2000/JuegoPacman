using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textName, textScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarDatos(string name, string score)
    {
        textName.text = name;
        textScore.text = score;
    }
}
