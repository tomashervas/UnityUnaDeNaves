using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionAsteroide : MonoBehaviour
{
    private Rigidbody Rig;

    private void Awake()
    {
        Rig = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Rig.angularVelocity = Random.insideUnitSphere * 5;
        //Rig.transform.position = new Vector3(0f, 0f, 9.5f);
    }
}
