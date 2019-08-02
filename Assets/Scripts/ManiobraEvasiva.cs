using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManiobraEvasiva : MonoBehaviour
{
    private Rigidbody rb;
    private float velocidadManiobra;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;

    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Start()
    {
        ActualizaLimites();
        StartCoroutine(Evasiva());
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

    IEnumerator Evasiva()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        while (true)
        {
            velocidadManiobra = Random.Range(2f, 5f) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(0.7f, 1.4f));
            velocidadManiobra = 0f;
            yield return new WaitForSeconds(Random.Range(0.5f, 0.7f));
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(velocidadManiobra, 0f, rb.velocity.z);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax), 0f, rb.position.z);
        rb.rotation = Quaternion.Euler(0f, 0f, -(rb.velocity.x * 8));
    }
}
