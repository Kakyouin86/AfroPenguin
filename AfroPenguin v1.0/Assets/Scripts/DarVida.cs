using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarVida : MonoBehaviour
{
   public int Energía = 5;

    public void OnTriggerEnter(Collider AumentoVida)
    {
        if(AumentoVida.gameObject.tag == "Player")
        {
            Jugador1 v = AumentoVida.GetComponent<Jugador1>();
            if(v.currentHealth != 100)
                { v.currentHealth += Energía;
                Destroy(gameObject);
                }
            else
            {
                v.currentHealth = 100;
            }
        }
    }
}
