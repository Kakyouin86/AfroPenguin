using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPivote : MonoBehaviour
{

    public Transform objetivo;
    public float velocidadRotacion;

    void Update()
    {
        transform.position = objetivo.position;
        Vector3 rotacion = transform.eulerAngles;
        rotacion.y += Input.GetAxis("Mouse X") * velocidadRotacion * Time.deltaTime;
        rotacion.x -= Input.GetAxis("Mouse Y") * velocidadRotacion * Time.deltaTime;
        rotacion.x = Mathf.Clamp(rotacion.x, 0, 50);

        transform.eulerAngles = rotacion;

    }
}
