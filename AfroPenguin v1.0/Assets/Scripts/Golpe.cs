using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Golpe : MonoBehaviour
{

    public GameObject BocaArmaBullet;
    public GameObject Bala;
    public float cantidadDeTiros;
    private float nextTiro;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextTiro)

        {
            Disparo();
        }
    }

    void Disparo()
        {
        nextTiro = Time.time + cantidadDeTiros;
        //BocaArma.GetComponent<Transform>().position
        Instantiate(Bala, BocaArmaBullet.GetComponent<Transform>().position, BocaArmaBullet.GetComponent<Transform>().rotation);
        
    }
}
