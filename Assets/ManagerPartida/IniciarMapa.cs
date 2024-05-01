using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarMapa : MonoBehaviour
{
    [SerializeField] GameObject plataformaParent;
    [SerializeField] GameObject hieloParent;
    [SerializeField] GameObject startCartel;
    [SerializeField] float delayActivarTodo;
    [SerializeField] GameObject cronometro;
    // Start is called before the first frame update

    public void Iniciar()
    {
        Invoke("ActivarTodo", delayActivarTodo);
    }

    void ActivarTodo()
    {
        plataformaParent.SetActive(true);
        hieloParent.SetActive(true);
        startCartel.SetActive(true);
        cronometro.SetActive(true);
    }
}
