using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody RigDisparo;
    public float velocidad;

    private void Awake()
    {
        RigDisparo = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RigDisparo.velocity = transform.forward * velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
