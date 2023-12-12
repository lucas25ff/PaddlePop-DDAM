using UnityEngine;
//REFIERE AL SONIDO QUE EFECTUA LA PELOTA CUANDO COLISIONA
public class ReproducirSonidoColision : MonoBehaviour
{
    public AudioClip sonidoColision;

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*aqui preguntamos si la pelota choca con alguna de las paletas, esto se hace mediante las etiquetas asignadas en el inspector. 
        Si esto ocurre se reproduce el sonido asignado*/
        if (collision.gameObject.CompareTag("Paddle1") || collision.gameObject.CompareTag("Paddle2"))
        {
            ReproducirSonido();
        }
    }

    void ReproducirSonido()
    {
        //aqui verificamos si el objeto con el que choca tiene asignado el audiosource
        AudioSource audioSource = GetComponent<AudioSource>();

        //en caso de que de como nulo, es decir que no tenga le agregamos
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        //luego de asignarlo, lo reproducimos
        audioSource.clip = sonidoColision;
        audioSource.Play();
    }
}

