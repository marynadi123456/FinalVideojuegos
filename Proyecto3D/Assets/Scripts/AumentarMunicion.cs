using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class AumentarMunicion : MonoBehaviour
{
    public Disparo disparo;
    // Start is called before the first frame update
    void Start()
    {
        if(disparo==null){
            disparo= GetComponent<Disparo>();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coleccion"))
        {
            LeanPool.Despawn(other);
            GameManager.instance.ColeccionMunicion();
            disparo.balasNormales += 20;
            disparo.MostrarMunicion();
        }    
    }
}
