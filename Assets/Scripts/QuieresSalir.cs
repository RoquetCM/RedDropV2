using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UISeleccionDeNiveles : MonoBehaviour
{

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
        Debug.Log("no");
    }

    public void PulsarBotonSalir()
    {
        Application.Quit(); 
        Debug.Log("si");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
