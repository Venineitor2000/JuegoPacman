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

    private void Update()
    {
        Debug.Log(record.ToString("F2"));
        Debug.Log(record);
        Debug.Log((int)(record * 100));
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
