using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionPlayer : MonoBehaviour
{
    float record = Mathf.Infinity;
    [SerializeField] Cronometro cronometro;
    public void UpdatePuntuacion()
    {
        float nuevaPuntuacion = cronometro.GetTime();;
        if (record < nuevaPuntuacion)
            return;
        record = nuevaPuntuacion;


    }

    public string GetTimeRecordInString()
    {
        return record.ToString("F2");
    }

    public int GetTimeRecordInScore()
    {
        
        return (int)(record * 100);
    }
}
