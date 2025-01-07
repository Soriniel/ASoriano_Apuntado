using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    GameObject Bala;
    GameObject Salida;
    GameObject Cruceta;
    Vector3 posicionInicial;
    public float velocidad;
    public int velocidadi;
    public float tiempoInicio;
    public GameManager gameManager;
    public AudioClip sonidoDisparo;
    AudioSource fuenteSonido;

    // Start is called before the first frame update
    void Start()
    {
        Salida = GameObject.Find("Salida");
        Cruceta = GameObject.Find("Cruceta");

        gameManager = FindObjectOfType<GameManager>();

        posicionInicial = Salida.transform.position;

        fuenteSonido = this.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        posicionInicial = Salida.transform.position;
        Salida.transform.LookAt(Cruceta.transform);
        Bala = Resources.Load<GameObject>("Bala");

        // Detectar inicio de disparo (presionar Espacio)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tiempoInicio = Time.time;
            Debug.Log("Disparo iniciado: " + tiempoInicio);
        }

        // Detectar fin de disparo (soltar Espacio)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            fuenteSonido.clip = sonidoDisparo;
            fuenteSonido.Play();
            float tiempoFinal = Time.time;
            Debug.Log("Disparo finalizado: " + tiempoFinal);

            velocidad = tiempoFinal - tiempoInicio;
            velocidad = velocidad * 20;
            velocidadi = (int)velocidad;

            Debug.Log("Velocidad calculada: " + velocidad);

            // Crear la bala
            Bala = Instantiate(Bala, posicionInicial, transform.rotation);
            Rigidbody rb = Bala.GetComponent<Rigidbody>();

            // Calcular dirección y aplicar velocidad
            Vector3 direccionDeDisparo = (Cruceta.transform.position - Bala.transform.position).normalized;
            Bala.transform.forward = direccionDeDisparo;
            rb.velocity = direccionDeDisparo * velocidad;

            // Incrementar contadores en el GameManager
            GameManager.IncNumBalas();
            GameManager.IncFuerza();
      
        }
    }

    public void Test()
    {
        Debug.Log("test");
     }
}
