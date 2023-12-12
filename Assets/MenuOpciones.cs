using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//ASIGNADO EN MENU DEL JUEGO EN "OPCIONES"
public class MenuOpciones : MonoBehaviour
{
    //referimos al audiomixer que asignamos en el inspector de Unity
    [SerializeField] private AudioMixer audioMixer;
    //aqui establecemos el metodo publico para que el usuario pueda config el audio del juego
    public void CambiarVolumen(float volumen)
    {
        //finalmente aqui asignamos el param de vol en el audiomixer
        audioMixer.SetFloat("Volumen", volumen);
    }
}
