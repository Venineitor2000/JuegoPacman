using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IngresarNombre : MonoBehaviour
{
    [SerializeField] TMP_InputField casillaNombre;
    [SerializeField] Button botonEnter;
    // Start is called before the first frame update
    void Start()
    {
        casillaNombre.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) 
        {
            Debug.Log("Hola");
            botonEnter.Select();
            botonEnter.onClick.Invoke();
        }   
    }
}
