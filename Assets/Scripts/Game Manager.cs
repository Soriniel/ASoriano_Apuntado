using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject[] posicionesDiana;
    public GameObject diana;
    static public TextMeshProUGUI Tbalas;
    static public TextMeshProUGUI Tdianas;
    static int numBalas = 0;
    static int numDianas = 1;

    // Start is called before the first frame update
    public void Start()
    {
        posicionesDiana = GameObject.FindGameObjectsWithTag("respawnDiana");
        diana           = Resources.Load<GameObject>("PDiana");

        GameObject contador = GameObject.Find("Contador");
        Tbalas              =  contador.GetComponent<TextMeshProUGUI>();

        GameObject contadorD = GameObject.Find("ContadorD");
        Tdianas              = contadorD.GetComponent<TextMeshProUGUI>();

        // MOVER LA ESFERA A UNA POSICI�N ALEATORIA
        int tamanyoArrayDianas = posicionesDiana.Length; // tama�o = 5
        int numeroAleatorio = Random.Range(0, tamanyoArrayDianas); // rango de 0 a 4

        GameObject dianaAleatoria = posicionesDiana[numeroAleatorio];

        Instantiate(diana, dianaAleatoria.transform.position, Quaternion.identity);

    }

    static public void IncNumBalas()
    {
        numBalas++;
        Tbalas.text = "Balas: " + numBalas;
    }

    static public void IncNumDianas()
    {
        numDianas++;
        Tdianas.text = "Dianas: " + numDianas;
    }

    public void GenerarNuevaDiana()
    {
        posicionesDiana = GameObject.FindGameObjectsWithTag("respawnDiana");
        diana = Resources.Load<GameObject>("PDiana");

        int tamanyoArrayDianas = posicionesDiana.Length;
        int numeroAleatorio = Random.Range(0, tamanyoArrayDianas);
        GameObject dianaAleatoria = posicionesDiana[numeroAleatorio];
        Instantiate(diana, dianaAleatoria.transform.position, Quaternion.identity);
        IncNumDianas();
        // CADA VEZ QUE UNA DIANA DESAPAREZCA, TENEMOS QUE LLAMAR
        // A ESTA FUNCI�N, PARA QUE GENERE UNA NUEVA MEDIANTE INSTANTIATE
    }




}

