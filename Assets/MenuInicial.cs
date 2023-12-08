using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    // Sirve para cargar una nueva escena
    public void Jugar()
    {
        // Reemplaza "NombreDeTuSiguienteEscena" con el nombre real de la siguiente escena
        SceneManager.LoadScene("JuegoDesarrolloApps");
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}

