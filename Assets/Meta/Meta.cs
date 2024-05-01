using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Meta : MonoBehaviour
{
    
    public UnityEvent OnPlayerGano = new UnityEvent();
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerGano?.Invoke();
        }
    }
}
