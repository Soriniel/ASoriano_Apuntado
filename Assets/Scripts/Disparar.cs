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
    // Start is called before the first frame update
    void Start()
    {
        
        Salida   = GameObject.Find("Salida");
        Cruceta  = GameObject.Find("Cruceta");

        GameManager gameManager = FindObjectOfType<GameManager>();

        posicionInicial = Salida.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        Salida.transform.LookAt(Cruceta.transform);
        Bala = Resources.Load<GameObject>("Bala");
    }

    public void OnMouseDown()
    {
        tiempoInicio =  Time.time;
        Debug.Log("1 - " + tiempoInicio);
    }
    public void OnMouseUp()
    {
        float tiempoFinal = Time.time;
        Debug.Log("2 - " + tiempoFinal);

        velocidad = tiempoFinal - tiempoInicio;
        velocidad = velocidad * 20;
        velocidadi = (int)velocidad;

        Debug.Log(velocidad);


        Bala = Instantiate(Bala, posicionInicial, transform.rotation);
        Rigidbody rb = Bala.GetComponent<Rigidbody>();


        Vector3 direccionDeDisparo = (Cruceta.transform.position - Bala.transform.position).normalized;
        Bala.transform.forward = direccionDeDisparo;
        rb.velocity = direccionDeDisparo * velocidad;

        GameManager.IncNumBalas();

        GameManager.IncFuerza();

    }
}
