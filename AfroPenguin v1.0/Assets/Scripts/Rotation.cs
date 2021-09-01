using UnityEngine;

//Attach this script to a GameObject to rotate around the target position.
public class Rotation : MonoBehaviour
{
    //Assign a GameObject in the Inspector to rotate around
    public GameObject Corazón;
    public float VelocidadRotación;
    //public float spawnTime = 20f;

    //void Start()
    //{
    //    InvokeRepeating("spawnCorazón", spawnTime, spawnTime);
    //}

    void Update()
    {
        transform.RotateAround(Corazón.transform.position, Vector3.up, VelocidadRotación * Time.deltaTime);
    }

    //void spawnCorazón()
    //{
    //var newCorazón = GameObject.Instantiate(Corazón);
    //}
}


