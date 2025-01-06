using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Timer timer;

    public float minX = -10f; // Límite mínimo en X
    public float maxX = 10f;  // Límite máximo en X
    public float minY = 0f;   // Límite mínimo en Y
    public float maxY = 5f;   // Límite máximo en Y

    public static GameObject diana;
    public static GameObject dianaA;
    public static GameObject boton;
    public static GameObject winner;
    public static GameObject loser;
    public static int numBalas = 0;
    public static int numDianas = -1;
    public static int numFuerza = 0;

    public static TextMeshProUGUI Tbalas;
    public static TextMeshProUGUI Tdianas;
    public static TextMeshProUGUI Tfuerza;
    public static TextMeshProUGUI resultadoFinalText;


    public static Disparar dispararScript;

    public static GameObject Cruceta;

    public AudioClip sonidoVictoria;
    public AudioClip sonidoDerrota;
    AudioSource fuenteSonido;

    public void Start()
    {
        fuenteSonido = this.GetComponent<AudioSource>();

        timer = FindObjectOfType<Timer>();

        dispararScript = GameObject.Find("Disparo").GetComponent<Disparar>();

        diana = Resources.Load<GameObject>("Target");
        Cruceta = GameObject.Find("Cruceta");
        boton = GameObject.Find("Button");
        winner = GameObject.Find("Winner");
        loser = GameObject.Find("Loser");

        GameObject contador = GameObject.Find("Contador");
        Tbalas = contador.GetComponent<TextMeshProUGUI>();

        GameObject contadorD = GameObject.Find("ContadorD");
        Tdianas = contadorD.GetComponent<TextMeshProUGUI>();

        GameObject fuerza = GameObject.Find("Fuerza");
        Tfuerza = fuerza.GetComponent<TextMeshProUGUI>();

        GameObject resultado = GameObject.Find("ResultadoFinal");
        resultadoFinalText = resultado.GetComponent<TextMeshProUGUI>();
        resultadoFinalText.gameObject.SetActive(false);
        winner.gameObject.SetActive(false);
        loser.gameObject.SetActive(false);


        GenerarNuevaDiana(); // Generar la primera diana
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

    static public void IncFuerza()
    {
        numFuerza = dispararScript.velocidadi;
        Tfuerza.text = "Fuerza: " + numFuerza;
    }

    public void GenerarNuevaDiana()
    {
        // Generar posición aleatoria dentro de los límites definidos
        float posX = Random.Range(minX, maxX);
        float posY = Random.Range(minY, maxY);

        Vector3 posicionAleatoria = new Vector3(posX, posY, 0f); // Suponiendo que Z es 0
        Instantiate(diana, posicionAleatoria, Quaternion.identity);
        IncNumDianas();
    }

    static public void FinalizarJuego()
    {
        float porcentajePrecision = numBalas > 0 ? ((float)numDianas  / numBalas) * 100 : 0;
        resultadoFinalText.gameObject.SetActive(true);
        resultadoFinalText.text = $"Dianas acertadas: {numDianas }\n" +
                                  $"Balas disparadas: {numBalas}\n" +
                                  $"Precisión: {porcentajePrecision:F2}%";

        if (numDianas >= 10 && porcentajePrecision > 50 )
        {
            Victoria();
        }
        else
        {
            Derrota();
        }

        OcultarElementos();
    }
    private static void OcultarElementos()
    {
        dianaA = GameObject.FindWithTag("Enemigo");

        if (Tbalas != null) Tbalas.gameObject.SetActive(false);
        if (Tdianas != null) Tdianas.gameObject.SetActive(false);
        if (Tfuerza != null) Tfuerza.gameObject.SetActive(false);
        if (Cruceta != null) Cruceta.gameObject.SetActive(false);
        if (dianaA != null) dianaA.gameObject.SetActive(false);
        if (boton != null) boton.gameObject.SetActive(false);

        dispararScript.enabled = false;


    }

    public static void Victoria()
    {
        winner.gameObject.SetActive(true);
    }
    private static void Derrota()
    {
        loser.gameObject.SetActive(true);
    }
}






