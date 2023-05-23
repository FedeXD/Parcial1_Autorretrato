using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesOpcion : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Reintentar()
    {
        SceneManager.LoadScene("Carrera");
    }

    public void Continuar()
    {
        SceneManager.LoadScene(2);
    }
}
