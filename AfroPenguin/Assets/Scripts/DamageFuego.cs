using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFuego : MonoBehaviour
{
    public AudioClip DañoFuego;
    public AudioSource audioSource;
    public int Daño = 20;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider fuego)
    {
        if (fuego.gameObject.tag == "Player")
        {
            Jugador1 v = fuego.GetComponent<Jugador1>();
            v.currentHealth -= Daño;
            audioSource.PlayOneShot(DañoFuego, 0.3f);

        }
    }
}
