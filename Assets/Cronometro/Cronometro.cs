using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cronometro : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    float startTime;
    float time;
    bool detenido;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (detenido)
            return;
        time = Time.time - startTime;
        text.text = time.ToString("F2");


    }

    public float GetTime()
    {
        return time;
    }

    public void Detener()
    {
        detenido = true;
    }
    
}
