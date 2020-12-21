using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Bala : MonoBehaviour
{
    void Start()
    {
        LeanPool.Despawn(gameObject,10f);
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            LeanPool.Despawn(gameObject);
        }
        
    }
}
