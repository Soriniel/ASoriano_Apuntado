using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    private GameObject Cruceta;
    private GameObject puntoCanon;

    void Start()
    {
        Cruceta = GameObject.Find("Cruceta");
        puntoCanon = GameObject.Find("Rotacion");
    }

    void Update()
    {
        // Movimiento de la cruceta
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoX, movimientoY, 0) * velocidad * Time.deltaTime;
        Cruceta.transform.Translate(movimiento);

        // Dirección hacia la cruceta
        Vector3 direccion = Cruceta.transform.position - puntoCanon.transform.position;

        // Rotar el cañón hacia la cruceta
        if (direccion != Vector3.zero) // Evita errores si la dirección es cero
        {
            puntoCanon.transform.rotation = Quaternion.LookRotation(direccion, Vector3.up);
        }
    }
}
