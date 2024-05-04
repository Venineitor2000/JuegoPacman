using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerFantasmas : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    static Queue<GameObject> fantasmas = new Queue<GameObject>();
    [SerializeField] int limiteFantasmas;

   

    public void GenerarFantasma(Vector2 posicion)
    {
        GameObject instancia = Instantiate(prefab, posicion, Quaternion.identity);
        fantasmas.Enqueue(instancia);
        Debug.Log(fantasmas.Count > limiteFantasmas);
        if (fantasmas.Any() && fantasmas.Count > limiteFantasmas)
            {
            GameObject fantasmaEliminar = fantasmas.Dequeue();
            Destroy(fantasmaEliminar);
            }
            
        
    }

    
}
