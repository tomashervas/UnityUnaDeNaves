using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject Disparo;
    public Transform PosicionDisparo;
    private AudioSource sonidoDisparo;
    public float PrimerDisp;
    public float cadencia;



    private void Awake()
    {
        sonidoDisparo = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Disparar", PrimerDisp, cadencia);
    }

    public void Disparar()
    {
        Instantiate(Disparo, PosicionDisparo.position, PosicionDisparo.rotation);
        sonidoDisparo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
