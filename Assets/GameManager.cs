using UnityEngine;
using TMPro;

//CONTROLADOR DE INSTANCIA Y PUNTAJES
public class GameManager : MonoBehaviour
{
    //declaramos las variables de tipo privada para almacenar las referencias que vemos en el puntaje del juego
    [SerializeField] private TMP_Text paddle1ScoreText;
    [SerializeField] private TMP_Text paddle2ScoreText;
    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    //asignamos las diferentes variables privadas para ir actualizando el puntaje de cada jugador
    private int paddle1Score;
    private int paddle2Score;
    private int maxScore = 5;  //variable para establecer el puntaje maximo

    //declaramos una variable estatica de instancia unica
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            //preguntamos si la instancia es nula. Si asi lo es refiere a que no se ha asignado una instancia al gamemanager
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void Paddle1Scored()
    {
        paddle1Score++;

        //preguntamos si el puntaje es el max
        if (paddle1Score >= maxScore)
        {
            //reiniciamos los puntajes a 0 si se alcanza el puntaje max
            paddle1Score = 0;
            paddle2Score = 0;

            //actualizamos el textmesh que seria el marcador que ve el usuario
            paddle1ScoreText.text = paddle1Score.ToString();
            paddle2ScoreText.text = paddle2Score.ToString();

            //restablecemos las posiciones
            Restart();
        }
        else
        {
            //actualizamos nuevamente el marcador de puntos
            paddle1ScoreText.text = paddle1Score.ToString();
        }
    }
    public void Paddle2Scored()
    {
        paddle2Score++;

        //verificamos si el puntaje es el max
        if (paddle2Score >= maxScore)
        {
            //reiniciamos los puntos
            paddle1Score = 0;
            paddle2Score = 0;

            //actualizamos el marcador de puntos
            paddle1ScoreText.text = paddle1Score.ToString();
            paddle2ScoreText.text = paddle2Score.ToString();

            //reestablecemos las posiciones 
            Restart();
        }
        else
        {
            //actualizamos nuevamente el marcador
            paddle2ScoreText.text = paddle2Score.ToString();
        }
    }

    //reiniciamos posiciones y puntos 
    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }
}


