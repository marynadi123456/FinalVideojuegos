
using UnityEngine;
using UnityEngine.SceneManagement;
public class CargarNivel : MonoBehaviour
{
    // Start is called before the first frame update
    public void CargarPrimero(){
        SceneManager.LoadScene(1);
    }

    public void SalirJuego(){
        Application.Quit();
    }

    public void VolverMenu(){
        SceneManager.LoadScene(0);
    }

    
}
