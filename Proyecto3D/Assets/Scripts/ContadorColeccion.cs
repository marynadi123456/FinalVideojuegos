using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ContadorColeccion : MonoBehaviour
{
    public static ContadorColeccion instance = null;
    public TextMeshProUGUI contadorObjetos;

    public GameObject avisos;

    TextMeshProUGUI textoAviso;

    public Vector3 posicionAparicion;

    Vector3 posicionOcultar;

    RectTransform posicionAviso;

    public GameObject meta;

    public float contador {get; set;}

    CanvasGroup canvasTexto;

    Sequence secuencia;
    
    // Start is called before the first frame update
    private void Awake() {
        if(instance ==null){
            instance = this;
        }else if(instance !=gameObject){
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
        contador = 0;
        posicionAviso = avisos.GetComponent<RectTransform>();
        posicionOcultar = posicionAviso.anchoredPosition3D;
        textoAviso = avisos.GetComponent<TextMeshProUGUI>();
        canvasTexto = avisos.GetComponent<CanvasGroup>();

        AnimacionAviso();
    }



    public void Conteo()
    {
        contador ++;
        contadorObjetos.text = contador.ToString();
        //Aqui la animacion
        

        AnimacionAviso();
        if(contador>=3)
        {
            GameManager.instance.TerminoColeccion();
            textoAviso.text = "Los coleccionaste todos. Ahora vuelve a la entrada.";
            meta.SetActive(true);
        }else{
            textoAviso.text = "Copa coleccionada";
        }
    }

    public void AnimacionAviso(){
        secuencia = DOTween.Sequence();
        secuencia.Append(posicionAviso.DOAnchorPos3D(posicionAparicion,0.3f))
            .Join(canvasTexto.DOFade(1,0.3f))
            .AppendInterval(2f)
            .Append(posicionAviso.DOAnchorPos3D(posicionOcultar,0.3f))
            .Join(canvasTexto.DOFade(0,0.3f));
    }
}
