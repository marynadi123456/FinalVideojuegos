using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    public AudioClip sonidoColeccion;
    public AudioClip sonidoFin;
    public AudioClip sonidoMonstruo;

    public AudioClip sonidoMunicion;
    public static GameManager instance =null;

    AudioSource source;
    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }else if(instance!=gameObject){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }
    public void MatoEnemigo()
    {
        source.PlayOneShot(sonidoMonstruo);
    }

    public void TerminoColeccion()
    {
        source.PlayOneShot(sonidoFin);
    }

    public void ColeccionConteo()
    {
        source.PlayOneShot(sonidoColeccion);
    }


    public void ColeccionMunicion(){
        source.PlayOneShot(sonidoMunicion);
    }

    public void SonidoColeccion()
    {
        source.PlayOneShot(sonidoColeccion);
    }
    
}
