using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    public GameManager gameManager;
    private GameObject panel;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        panel = GameObject.Find("Panel");

        panel.SetActive(false);
    }

    // Propiedad pública para acceder al tiempo restante


    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

        if (remainingTime <= 0)
        {
            panel.SetActive(true);
            GameManager.FinalizarJuego();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Nueva función para aumentar el tiempo (opcional si la usas)
    public void AddTime(float extraTime)
    {
        remainingTime += extraTime;
    }
}
