using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirTiempo : MonoBehaviour
{
    public float TiempoVida;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TiempoVida);
    }
}
