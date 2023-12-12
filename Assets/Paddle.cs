using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f; //le asignamos una vel a la paleta
    [SerializeField] private bool isPaddle1; // variable booleana
    private float yBound = 3.75f; //variable que indica la altura max que puede alcanzar la paleta
    void Update()
    {
        //obtenemos la entrada vertical del jugador en relacion de si es la paleta del jugador 1 o 2
        float movement;
        if (isPaddle1) //preguntamos si la
        {
            movement = Input.GetAxisRaw("Vertical");
        }else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        Vector2 paddlePosition = transform.position; // obtenemos la posicion actual de la paleta
        //aqui limitamos la posicion vertical de la paleta para que no se salga de los limites establecidos (las paredes)
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound); 
        transform.position = paddlePosition; //actualizamos la posicion de la paleta
    
    }
}
