using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using DG.Tweening;

public class Coleccion : MonoBehaviour
{
    Transform transformObjeto;
    Sequence secuencia;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ContadorColeccion.instance.Conteo();
            GameManager.instance.ColeccionConteo();
        
            LeanPool.Despawn(gameObject);
            
        }    
    }
}
