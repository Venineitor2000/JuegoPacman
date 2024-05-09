using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Button boton;
    public void PressPlay()
    {
        animator.enabled = true;
        boton.interactable = false;
    }
}
