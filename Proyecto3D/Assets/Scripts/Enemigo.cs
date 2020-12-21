using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Enemigo : MonoBehaviour
{
    public float vida = 50;

    public float quitaVida = 20;

    public AudioClip sonidoDano;

    AudioSource source;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    /*
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bala"))
        {
            QuitarVida();
            if(vida<=0)
            {
                GameManager.instance.MatoEnemigo();
                LeanPool.Despawn(gameObject);
            }
        }    
    }

    */
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bala"))
        {
            QuitarVida();
            if(vida<=0)
            {
                GameManager.instance.MatoEnemigo();
                LeanPool.Despawn(gameObject);
            }else{
                source.PlayOneShot(sonidoDano);
            }
        }       
    }

    void QuitarVida()
    {
        vida-=quitaVida;
    }
}
