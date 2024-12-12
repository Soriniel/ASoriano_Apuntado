using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    GameObject Bala;
    GameObject Salida;
    GameObject Cruceta;
    Vector3 posicionInicial;
    public float velocidad = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
        Salida   = GameObject.Find("Salida");
        Bala     = Resources.Load<GameObject>("Bala");
        Cruceta = GameObject.Find("Cruceta");

        posicionInicial = Salida.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        Salida.transform.LookAt(Cruceta.transform);
    }

    private void OnMouseDown()
    {
        Bala = Instantiate(Bala, posicionInicial, transform.rotation);
        Rigidbody rb = Bala.GetComponent<Rigidbody>();


        Vector3 direccionDeDisparo = (Cruceta.transform.position - Bala.transform.position).normalized;
        Bala.transform.forward = direccionDeDisparo;
        rb.velocity = direccionDeDisparo * velocidad;

    }
}
