using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    [SerializeField] private float maxVelocity = 30f;
    public AudioClip sonidoPunto;
    private Rigidbody2D ballRb;
    private AudioSource audioSource;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        audioSource = gameObject.AddComponent<AudioSource>();
        Launch();
    }

    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle1") || collision.gameObject.CompareTag("Paddle2"))
        {
            Rigidbody2D paddleRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 paddleVelocity = paddleRb ? paddleRb.velocity : Vector2.zero;

            //Debug.Log("Paddle Velocity: " + paddleVelocity);

            // Multiplicar la velocidad actual de la pelota por el factor de aumento
            ballRb.velocity = ballRb.velocity * velocityMultiplier;
            ballRb.velocity = Vector2.ClampMagnitude(ballRb.velocity, maxVelocity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            GameManager.Instance.Paddle2Scored();
            GameManager.Instance.Restart();
            Launch();
            ReproducirSonidoPunto();
        }
        else
        {
            GameManager.Instance.Paddle1Scored();
            GameManager.Instance.Restart();
            Launch();
            ReproducirSonidoPunto();
        }
    }

    private void ReproducirSonidoPunto()
    {
        audioSource.clip = sonidoPunto;
        audioSource.Play();
    }
}
