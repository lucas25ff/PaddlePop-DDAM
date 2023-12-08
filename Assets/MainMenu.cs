using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Inicio()
    {
        // Lógica para comenzar el juego (cargar la escena, iniciar el juego, etc.).
        SceneManager.LoadScene("JuegoDesarrolloApps");
    }

    public void Exit()
    {
        // Lógica para salir del juego.
        Application.Quit();
    }
}

