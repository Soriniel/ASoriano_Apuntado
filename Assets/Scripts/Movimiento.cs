using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    private GameObject Cruceta;

    // Start is called before the first frame update
    void Start()
    {
        Cruceta = GameObject.Find("Cruceta");

    }

    // Update is called once per frame
    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoX, movimientoY, 0) * velocidad * Time.deltaTime;
        Cruceta.transform.Translate(movimiento);

    }
}
