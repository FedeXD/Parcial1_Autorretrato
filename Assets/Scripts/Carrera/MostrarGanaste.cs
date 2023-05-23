using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarGanaste : MonoBehaviour
{
    public void Mostrar()
    {
        gameObject.SetActive(true);
    }

    public void Ocultar()
    {
        gameObject.SetActive(false);
    }
}
