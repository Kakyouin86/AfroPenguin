using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeCompoBlazer : MonoBehaviour
{
    public float tiempoDeVidaBala;
    public float velocidadBala;
    public ParticleSystem explosion;

    private void Awake()
    {
        Invoke("Destruir", tiempoDeVidaBala);
    }

    void Update()
    {
        transform.Translate(0, 0, velocidadBala * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;
        if (other.CompareTag("Escena")) return;

        Destroy(other.gameObject);
        Destruir();
        Instantiate(explosion, transform.position, transform.rotation);

    }
    private void Destruir()
    {
        Destroy(gameObject);
    }
}
