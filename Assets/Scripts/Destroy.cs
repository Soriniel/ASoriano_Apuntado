using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
   public GameManager gameManager;
    private Timer timer;
    // Start is called before the first frame update
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        timer.AddTime(3f);        
        Destroy(gameObject);
        Destroy(other.gameObject);

        gameManager.GenerarNuevaDiana();


    }
}
