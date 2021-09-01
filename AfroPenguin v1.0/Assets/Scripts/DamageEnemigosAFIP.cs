using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemigosAFIP : MonoBehaviour
{
    public int Daño = 99999;
    public void OnTriggerEnter(Collider Enemigos)
    {
        if (Enemigos.gameObject.tag == "Player")
        {
            Jugador1 v = Enemigos.GetComponent<Jugador1>();
            v.currentHealth -= Daño;
        }
    }
}
