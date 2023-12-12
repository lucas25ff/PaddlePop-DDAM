using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Inicio()
    {
        SceneManager.LoadScene("JuegoDesarrolloApps"); //comenzamos el juego 
    }

    public void Exit()
    {
        Application.Quit(); //salimos del juego
    }
}

