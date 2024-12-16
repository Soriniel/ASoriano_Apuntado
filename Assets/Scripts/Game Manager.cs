using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] posicionesDiana;
    public GameObject diana;

    // Start is called before the first frame update
    public void Start()
    {
        posicionesDiana = GameObject.FindGameObjectsWithTag("respawnDiana");
        diana           = Resources.Load<GameObject>("PDiana");

        // MOVER LA ESFERA A UNA POSICI�N ALEATORIA
        int tamanyoArrayDianas = posicionesDiana.Length; // tama�o = 5
        int numeroAleatorio = Random.Range(0, tamanyoArrayDianas); // rango de 0 a 4

        GameObject dianaAleatoria = posicionesDiana[numeroAleatorio];

        Instantiate(diana, dianaAleatoria.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void GenerarNuevaDiana()
    {
        posicionesDiana = GameObject.FindGameObjectsWithTag("respawnDiana");
        diana = Resources.Load<GameObject>("PDiana");

        int tamanyoArrayDianas = posicionesDiana.Length;
        int numeroAleatorio = Random.Range(0, tamanyoArrayDianas);
        GameObject dianaAleatoria = posicionesDiana[numeroAleatorio];
        Instantiate(diana, dianaAleatoria.transform.position, Quaternion.identity);
        // CADA VEZ QUE UNA DIANA DESAPAREZCA, TENEMOS QUE LLAMAR
        // A ESTA FUNCI�N, PARA QUE GENERE UNA NUEVA MEDIANTE INSTANTIATE
    }




}

