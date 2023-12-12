using UnityEngine;

public class Ball : MonoBehaviour
{
    //indicamos que queremos establecer una velocidad inicial la cual la ajustamos y la establecemos
    [SerializeField] private float initialVelocity = 4f;
    //Aqui le indicamos que va a multiplicar la velocidad de la pelota por el valor asignado
    [SerializeField] private float velocityMultiplier = 1.1f;
    //establecemos una vel max para que no la sobrepase
    [SerializeField] private float maxVelocity = 30f;
    /*aqui tenemos las variables que asignan algunas caracteristicas del juego como lo son el sonido  y
    el control de la fisica del juego*/
    public AudioClip sonidoPunto;
    private Rigidbody2D ballRb;
    private AudioSource audioSource;

    //aqui activamos la pelota dentro de la escena con la funcion start
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        //asignamos el componente de audio
        audioSource = gameObject.AddComponent<AudioSource>();
        //con la funcion launch le iniciamos el comportamiento del elemento
        Launch();
    }

    private void Launch()
    {
        //buscamos obtener un valor aleatorio que puede ser 0 o 1, luego si es 0 le asignamos 1 y si es 1 es -1 uno u otr  y asignar 1 si es 0, o -1 si es 1
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        //establecemos la velocidad del comp rigidbody usando la velcidad inicial y las direcciones aleatorias
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle1") || collision.gameObject.CompareTag("Paddle2"))
        {
            //aqui obtenemos el rigidbody del objeto con el que chocamos que seria la paleta
            Rigidbody2D paddleRb = collision.gameObject.GetComponent<Rigidbody2D>();
            //obtenemos la vel de la paleta, en caso de que sea nulo se establece la vel como vector2.zero
            Vector2 paddleVelocity = paddleRb ? paddleRb.velocity : Vector2.zero;

            //Debug.Log("Paddle Velocity: " + paddleVelocity); (comprobacion)

            //multiplicamos la velocidad actual de la pelota por el factor de aumento
            ballRb.velocity = ballRb.velocity * velocityMultiplier;
            //multiplicamos la velocidad actual de la pelota por el factor de aumento que seria velocitymultiplier
            ballRb.velocity = Vector2.ClampMagnitude(ballRb.velocity, maxVelocity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            //incrementamos la puntuacion del paddle2 en el gamemanager
            GameManager.Instance.Paddle2Scored();
            //aqui reiniciamos la posicion en la que se encuentra la pelota y reiniciamos la vel
            GameManager.Instance.Restart();
            Launch(); //lanzamos nuevamente la pelota
            ReproducirSonidoPunto();
        }
        else
        {
            //se incrementa la puntuacion en el gamemanager
            GameManager.Instance.Paddle1Scored();
            //se reinicia nuevamente la pelota y vel de la misma
            GameManager.Instance.Restart();
            Launch(); //lanzamos nuevamente
            ReproducirSonidoPunto();
        }
    }

    private void ReproducirSonidoPunto()
    {
        //configuramos el audioclip del componente audiosource con el sonido asociado a este
        audioSource.clip = sonidoPunto;
        audioSource.Play();
    }
}
