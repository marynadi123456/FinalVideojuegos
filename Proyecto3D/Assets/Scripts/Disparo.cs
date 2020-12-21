using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using TMPro;
using DG.Tweening;

public class Disparo : MonoBehaviour
{
    public GameObject bala;

    public float demoraDisparo;

    public float balasNormales;

    public float fuerzaDisparo;

    public TextMeshProUGUI mostrarBalas;

    public Transform posicionDisparo;

    public bool puedeDisparar;

    public Vector3 posicionRetroceso;

    Vector3 posicionOriginal;

    AudioSource source;

    bool enPausa;

    Sequence secuencia;

    public Transform posicionArma;

    public AudioClip sonidoDisparo;
    void Start()
    {
        enPausa = false;
        source = GetComponent<AudioSource>();

        posicionOriginal = posicionArma.localPosition;
        puedeDisparar =true;
        MostrarMunicion();
    }

    // Update is called once per frame
    void Update()
    {
        if(!enPausa)
            {
            if(SimpleInput.GetButtonDown("Fire1") && puedeDisparar && balasNormales>0)
            {
                DisparoBala();
            }
        }
        
    }

    void DisparoBala()
    {
        var balaDisparada =LeanPool.Spawn(bala,posicionDisparo.position,posicionDisparo.rotation);
        balasNormales --;
        source.PlayOneShot(sonidoDisparo);
        MostrarMunicion();
        puedeDisparar = false;
        balaDisparada.GetComponent<Rigidbody>().AddForce(fuerzaDisparo * posicionDisparo.up, ForceMode.Impulse);
        StartCoroutine(TiempoEsperaDisparo());
        secuencia = DOTween.Sequence();
        secuencia.Append(posicionArma.DOLocalMove(posicionRetroceso,0.15f))
            .Join(posicionArma.DOLocalRotate(new Vector3(-15,0,0),0.15f))
            .Append(posicionArma.DOLocalMove(posicionOriginal,0.25f))
            .Join(posicionArma.DOLocalRotate(Vector3.zero,0.25f));
        /*
        
        */
        
        
    }

    public void CambiarDisparo(){
        enPausa =!enPausa;
    }

    IEnumerator TiempoEsperaDisparo()
    {
        
        yield return new WaitForSeconds(demoraDisparo);
        puedeDisparar = true;
    }

    public void MostrarMunicion()
    {
        mostrarBalas.text = balasNormales.ToString();
    }
}
