using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirContacto : MonoBehaviour
{
    public GameObject ExplosionAsteroide;
    public GameObject ExplosionNave;
    

    public int valorPuntuacion;
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("limite"))
        {
            if (other.CompareTag("disparo") && !CompareTag("disparoEnemigo"))
            {
                gameController.AñadirPuntuacion(valorPuntuacion);
            }
            if (other.CompareTag("Player"))
            {
                Instantiate(ExplosionNave, other.transform.position, other.transform.rotation);
                gameController.IniciaGameOver();
            }
            
            if (!other.CompareTag("disparoEnemigo") && !other.CompareTag("Enemigo"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                if (ExplosionAsteroide != null)
                {
                    Instantiate(ExplosionAsteroide, transform.position, transform.rotation);
                }
            }
            
        }
    }
}
