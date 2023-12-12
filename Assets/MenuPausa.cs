using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//REFIERE AL MENU QUE VISUALIZA EL JUGADOR CUANDO LE DA PAUSA
public class MenuPausa : MonoBehaviour
{
    //aqui mostramos estas variables para que sean visibles 
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    public void Pausa(){
        Time.timeScale = 0f; //establecemos el tiempo en el que se detiene el juego al tocar ese boton
        //ocultamos el boton anterior y luego hacemos visible el otro menu
        botonPausa.SetActive(false); 
        menuPausa.SetActive(true);

    }
    //metodo para reanudar el juego
    public void Reanudar(){
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    //metodo para reiniciar el juego (puntajes y posiciones)
    public void Reiniciar(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //carga nuevamente la escena
    }
    public void Cerrar(){
        Debug.Log("Cerrando juego"); //mensaje en consola diciendo que estamos saliendo del juego
        Application.Quit();
    }
}
