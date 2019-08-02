using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazaFondo : MonoBehaviour
{
    public float velocidadDesplaza;
    private Vector3 PosInicial;
    private float TamañoFondo;

    // Start is called before the first frame update
    void Start()
    {
        PosInicial = transform.position;
        TamañoFondo = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float nuevaPosicion = Mathf.Repeat(Time.time * velocidadDesplaza, TamañoFondo);
        transform.position = PosInicial + Vector3.forward * nuevaPosicion;
    }
}
