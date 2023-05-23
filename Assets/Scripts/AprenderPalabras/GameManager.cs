using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text[] letras;
    bool estanTodasActivas = true;
    void Update()
    {
        estanTodasActivas = true; // Establecer el valor inicial como verdadero

        foreach (Text letra in letras)
        {
            if (!letra.gameObject.activeSelf)
            {
                estanTodasActivas = false;
                break; // Si se encuentra un objeto inactivo, puedes detener la iteración
            }
        }

        if (estanTodasActivas)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    

