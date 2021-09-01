using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GolpeBlazer : MonoBehaviour
{

    public GameObject BocaArmaBlazer;
    public GameObject BalaBlazer;
    public float cantidadDeTiros;
    private float nextTiro;

    void Update()
    {
        if (Input.GetButton("Fire2") && Time.time > nextTiro)

        {
            Disparo();
        }
    }

    void Disparo()
        {
        nextTiro = Time.time + cantidadDeTiros;
        //BocaArma.GetComponent<Transform>().position
        Instantiate(BalaBlazer, BocaArmaBlazer.GetComponent<Transform>().position, BocaArmaBlazer.GetComponent<Transform>().rotation);
        
    }
}
