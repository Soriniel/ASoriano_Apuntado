using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{

    public void EscenaFacil(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
