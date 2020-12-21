
using UnityEngine;
using DG.Tweening;

public class ComportamientoUI : MonoBehaviour
{
    RectTransform escala;


    // Start is called before the first frame update
    void Start()
    {
        escala = GetComponent<RectTransform>();
        
    }

    public void EscalarUno()
    {
        escala.DOScale(Vector3.one,0.5f);
    }

    public void EscalarCero()
    {
        escala.DOScale(Vector3.zero,0.5f);
    }
}
