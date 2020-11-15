using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drzwi : MonoBehaviour
{
    private Animator animator;
    private bool drzwi_open; 
    void Start()
    {
        drzwi_open = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            drzwi_open = true;
            Kontroler("open");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            drzwi_open = false;
            Kontroler("close");
        }
    }

    void Kontroler(string kierunek)
    {
        animator.SetTrigger(kierunek);
    }
}
