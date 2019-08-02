using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] Asteroides;
    public int NumPeligro;
    public float EsperaPeligro;
    public float EsperaOla;

    Vector2 xmitad;
    
    //UI
    private int Marcador;
    public Text TextoMarcador;
    public GameObject GameOverObjeto;
    public GameObject RestartObjeto;
    private bool GameOver;
    private bool Restart;



    // Start is called before the first frame update
    void Start()
    {
        GameOverObjeto.SetActive(false);
        RestartObjeto.SetActive(false);
        GameOver = false;
        Restart = false;
        Marcador = 0;
        ActualizaMarcador();
        StartCoroutine(GenerarPeligro());
        xmitad = Utilidades.ConsigueDimensiones() / 2;
        //Debug.Log(xmitad);
    }

    private void Update()
    {
        if(Restart && Input.GetKeyDown(KeyCode.R))
        {
            RestartMetodo();
        }
    }

    public void RestartMetodo()
    {
        SceneManager.LoadScene("main");
    }

    // Update is called once per frame
    IEnumerator GenerarPeligro()
    {
        while (!GameOver)
        {
            for (int i = 0; i < NumPeligro; i++)
            {
                
                Vector3 vector = new Vector3(Random.Range(-xmitad.x, xmitad.x), 0f, 14f);
                Instantiate(Asteroides[Random.Range(0,Asteroides.Length)], vector, Quaternion.identity);
                yield return new WaitForSeconds(EsperaPeligro);
            }

            yield return new WaitForSeconds(EsperaOla);
        }
        RestartObjeto.SetActive(true);
        Restart = true;
        //Debug.Log("gameOver");
    }

    public void ActualizaMarcador()
    {
        TextoMarcador.text = "Puntuación: " + Marcador;
    }

    public void AñadirPuntuacion(int valor)
    {
        Marcador += valor;
        ActualizaMarcador();
    }

    public void IniciaGameOver()
    {
        GameOverObjeto.SetActive(true);
        GameOver = true;
    }
}
