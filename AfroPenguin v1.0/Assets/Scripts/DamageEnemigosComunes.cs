using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemigosComunes : MonoBehaviour
{
    public int Daño = 40;
    public AudioClip DañoEnemigos;
    public AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider Enemigos)
    {
        if (Enemigos.gameObject.tag == "Player")
        {
            Jugador1 v = Enemigos.GetComponent<Jugador1>();
            v.currentHealth -= Daño;
            audioSource.PlayOneShot(DañoEnemigos, 0.3f);

        }
    }
}
