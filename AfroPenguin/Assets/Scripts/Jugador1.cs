using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador1 : MonoBehaviour
{

    private CharacterController controlador;
    private Animator anim;
    public AudioClip unEuro;
    public AudioClip diezPesos;
    public AudioClip cienDólares;
    public AudioClip cienPesos;
    public AudioClip quinientosYen;
    public AudioClip GameOver;
    public AudioClip miniHeart;
    public AudioClip Puchos;
    public AudioClip Birra;
    public AudioSource audioSource;
    public bool alreadyPlayed = false;


    [Header("Movimientos")]
    public int Velocidad;
    public float gravedad;
    public float fuerzaSalto;
    public float VelGiroAire;
    public float VelGiroPiso;

    [Header("Energía Personaje")]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    //private bool isCoroutineExecuting = false;

    public ParticleSystem MorirEplosión;

    private Vector3 moverDireccion;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);

        float girar = Input.GetAxis("Horizontal");
        if (controlador.isGrounded)
        {

            if (Input.GetButton("Vertical"))
            {
                moverDireccion = transform.forward * Input.GetAxis("Vertical") * Velocidad;
                anim.SetInteger("AnimaParam", 1);
            }
            else
            {
                anim.SetInteger("AnimaParam", 0);
                moverDireccion = transform.forward * Input.GetAxis("Vertical") * 0;
            }

            if (Input.GetButton("Jump"))
            {
                anim.SetInteger("AnimaParam", 2);
                moverDireccion.y = fuerzaSalto;
            }
            //Giro en el piso.
            transform.Rotate(0, VelGiroPiso * girar * Time.deltaTime, 0);
        }
        else
        // Giro en el aire si no está grounded.
        {
            transform.Rotate(0, VelGiroAire * girar * Time.deltaTime, 0);
        }

        controlador.Move(moverDireccion * Time.deltaTime);
        moverDireccion.y -= gravedad * Time.deltaTime;

        /////////////////Termina movimiento acá.

        //if (ShooterAgent.AllowedToShoot == false) return; // if not allowed to shoot, don't run the code bellow
                                             // your code

        if (Input.GetButton("Fire1"))
                anim.SetInteger("AnimaParam", 3);
            else if (Input.GetButton("Fire2"))
                anim.SetInteger("AnimaParam", 5);
        
        /////////////////Termina ataque acá.

    }

    public void OnTriggerEnter(Collider other)
    {
        //Did I hit an enemy?
        if (other.CompareTag("Enemy"))
        {
            anim.SetInteger("AnimaParam", 4);
            if (currentHealth <= 0)
            {
                //gameObject.SetActive(false);
                //Instantiate(MorirEplosión, transform.position, transform.rotation);
                //Invoke("DelayAntesDeMorir", 2f);
                //StartCoroutine(ExecuteAfterTime(2));
                //Invoke("EjecutarGameOver", 2);
                GameManager.instance.GameOver();
                //anim.SetInteger("AnimaParam", 4);
            }

        }
        if (other.CompareTag("Heart"))
        {
            if (currentHealth != 100)
            audioSource.PlayOneShot(miniHeart, 0.3f);

        }

        //Did I hit a coin?
        else if (other.CompareTag("Coin 500 Yen"))
        {
            GameManager.instance.AddScore(5);

            //audioSource.Play();
            //audioSource.clip = sonidoMoneda;
            //audioSource.PlayOneshot = variable del clip
            Destroy(other.gameObject);
            audioSource.PlayOneShot(quinientosYen, 0.3f);
            //alreadyPlayed = true;
        }

        else if (other.CompareTag("Note 100 Dólares"))
        {
            GameManager.instance.AddScore(100);

            //audioSource.Play();
            //audioSource.clip = sonidoMoneda;
            //audioSource.PlayOneshot = variable del clip
            Destroy(other.gameObject);
            audioSource.PlayOneShot(cienDólares, 0.3f);
            //alreadyPlayed = true;
        }

        else if (other.CompareTag("Note 10 Pesos"))
        {
            GameManager.instance.AddScore(-50);

            //audioSource.Play();
            //audioSource.clip = sonidoMoneda;
            //audioSource.PlayOneshot = variable del clip
            Destroy(other.gameObject);
            audioSource.PlayOneShot(diezPesos, 0.4f);
            //alreadyPlayed = true;
        }

        else if (other.CompareTag("Note 100 Pesos"))
        {
            GameManager.instance.AddScore(-100);

            //audioSource.Play();
            //audioSource.clip = sonidoMoneda;
            //audioSource.PlayOneshot = variable del clip
            Destroy(other.gameObject);
            audioSource.PlayOneShot(cienPesos, 0.3f);
            //alreadyPlayed = true;
        }

        else if (other.CompareTag("Coin 1 Euro"))
        {
            GameManager.instance.AddScore(1);

            //audioSource.Play();
            //audioSource.clip = sonidoMoneda;
            //audioSource.PlayOneshot = variable del clip
            Destroy(other.gameObject);
            audioSource.PlayOneShot(unEuro, 0.3f);
            //alreadyPlayed = true;
        }

        else if (other.CompareTag("Puchos"))
        {
            GameManager.instance.AddScore(-5);

            //audioSource.Play();
            //audioSource.clip = sonidoMoneda;
            //audioSource.PlayOneshot = variable del clip
            Destroy(other.gameObject);
            audioSource.PlayOneShot(Puchos, 0.3f);
            //alreadyPlayed = true;
        }

        else if (other.CompareTag("Cerveza"))
        {
            GameManager.instance.AddScore(-2);

            //audioSource.Play();
            //audioSource.clip = sonidoMoneda;
            //audioSource.PlayOneshot = variable del clip
            Destroy(other.gameObject);
            audioSource.PlayOneShot(Birra, 0.3f);
            //alreadyPlayed = true;
        }

        //Did I hit the Goal?
        else if (other.CompareTag("Goal"))
        {
            GameManager.instance.LevelEnd();

        }
    }
    public void EjecutarGameOver()

    {
        GameManager.instance.GameOver();
    }
}



//if (condition)
//{
//    // executed only if "condition" is true
//}
//else if (other condition)
//{
//    // executed only if "condition" was false and "other condition" is true
//}
//else
//{
    // executed only if both "condition" and "other condition" were false
//}
//The if portion is the only block that is absolutely mandatory. else if allows you to say "ok, if the previous condition was not true, 
//then if this condition is true...". The else says "if none of the conditions above were true..."
//You can have multiple else if blocks, but only one if block and only one (or zero) else blocks.

