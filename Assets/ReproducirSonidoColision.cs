using UnityEngine;

public class ReproducirSonidoColision : MonoBehaviour
{
    public AudioClip sonidoColision;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si la colisión es con una paleta
        if (collision.gameObject.CompareTag("Paddle1") || collision.gameObject.CompareTag("Paddle2"))
        {
            ReproducirSonido();
        }
    }

    void ReproducirSonido()
    {
        // Verifica si el objeto con el que colisionamos tiene un AudioSource
        AudioSource audioSource = GetComponent<AudioSource>();

        // Si no tiene un AudioSource, lo agregamos
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asignamos el sonido al AudioSource y lo reproducimos
        audioSource.clip = sonidoColision;
        audioSource.Play();
    }
}

