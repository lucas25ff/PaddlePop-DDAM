using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//REFIERE A TODA LA INTERFAZ DEL MENU INICIAL
public class MenuInicial : MonoBehaviour
{
    //cargamos la nueva escena
    public void Jugar()
    {
        //asignamos el nombre que en este caso es "JDA"
        SceneManager.LoadScene("JuegoDesarrolloApps");
    }

    public void Salir()
    {
        //aqui detenemos la reproduccion del juego
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

