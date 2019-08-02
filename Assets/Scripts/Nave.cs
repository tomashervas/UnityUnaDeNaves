using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Nave : MonoBehaviour
{
    private float velocidad;
    private Rigidbody RigNave;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;

    //variables disparo
    public GameObject Disparo;
    public Transform PuntoDisparo;
    public float TasaDisparo;
    private float SiguienteDisparo;

    // Start is called before the first frame update
    void Awake()
    {
        velocidad = 10;
        RigNave = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        ActualizaLimites();
    }

    public void ActualizaLimites()
    {
        Vector2 mitad = Utilidades.ConsigueDimensiones() / 2;
        //Debug.Log(mitad);
        xMin = -mitad.x + 0.7f;
        xMax = mitad.x - 0.7f;
        zMin = -mitad.y + 6f;
        zMax = mitad.y;
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time>SiguienteDisparo)
        {
            SiguienteDisparo = Time.time + TasaDisparo;
            Instantiate(Disparo, PuntoDisparo.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        float movimientoH = CrossPlatformInputManager.GetAxis("Horizontal");
        float movimientoV = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0f, movimientoV);
        RigNave.velocity = movimiento * velocidad;
        RigNave.position = new Vector3(Mathf.Clamp(RigNave.position.x, xMin, xMax), 0f, Mathf.Clamp(RigNave.position.z, zMin, zMax));
        RigNave.rotation = Quaternion.Euler(0f, 0f, -(RigNave.velocity.x * 4));
    }
}
