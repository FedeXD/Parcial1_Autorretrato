using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraSeguir : MonoBehaviour
{
    public Transform target; // Referencia al objeto que seguirá la cámara
    public Vector3 offset = new Vector3(0, 10, 0); // Desplazamiento de la cámara con respecto al objeto
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del seguimiento de la cámara
    public float targetHeight = 10f; // Altura a la que la cámara apuntará
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + new Vector3(offset.x, targetHeight, offset.z);

        // Interpola suavemente la posición actual de la cámara hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition; // Actualiza la posición de la cámara
        transform.LookAt(target); // Hace que la cámara mire hacia el objeto que está siguiendo
    }

}
