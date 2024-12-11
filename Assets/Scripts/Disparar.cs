using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    GameObject Bala;
    GameObject Salida;
    Vector3 posicionInicial;
    public float velocidad = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
        Salida = GameObject.Find("Salida");
        Bala   = Resources.Load<GameObject>("Bala");

        posicionInicial = Salida.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Bala = Instantiate(Bala, posicionInicial, transform.rotation);
        Rigidbody rb = Bala.GetComponent<Rigidbody>();

        Vector3 direccionDeDisparo = new Vector3(0f, 1f, 1f).normalized; // o tambi�n podr�as usar un Vector3 fijo, como Vector3.forward si quieres disparar hacia el frente global
        rb.velocity = direccionDeDisparo * velocidad;

    }
}
