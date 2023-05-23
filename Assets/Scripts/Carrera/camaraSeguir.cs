using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraSeguir : MonoBehaviour
{
    public Transform objetivo; //Objeto que va a seguir la cámara
    public Vector3 offset = new Vector3(0, 10, 0); //Desplazamiento de la cámara con respecto al objeto
    public float velocidadSuave = 0.125f; // Velocidad de suavizado del seguimiento de la cámara
    public float alturaObjetivo = 10f; // Altura a la que la cámara apuntará
    void LateUpdate()
    {
        Vector3 desiredPosition = objetivo.position + new Vector3(offset.x, alturaObjetivo, offset.z);

        //Interpola suavemente la posición actual de la cámara hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, velocidadSuave);

        transform.position = smoothedPosition; //Actualiza la posición de la cámara
        transform.LookAt(objetivo); //Hace que la cámara mire hacia el objeto que está siguiendo
    }

}
