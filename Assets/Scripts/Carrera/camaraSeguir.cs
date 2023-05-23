using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraSeguir : MonoBehaviour
{
    public Transform objetivo; //Objeto que va a seguir la c�mara
    public Vector3 offset = new Vector3(0, 10, 0); //Desplazamiento de la c�mara con respecto al objeto
    public float velocidadSuave = 0.125f; // Velocidad de suavizado del seguimiento de la c�mara
    public float alturaObjetivo = 10f; // Altura a la que la c�mara apuntar�
    void LateUpdate()
    {
        Vector3 desiredPosition = objetivo.position + new Vector3(offset.x, alturaObjetivo, offset.z);

        //Interpola suavemente la posici�n actual de la c�mara hacia la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, velocidadSuave);

        transform.position = smoothedPosition; //Actualiza la posici�n de la c�mara
        transform.LookAt(objetivo); //Hace que la c�mara mire hacia el objeto que est� siguiendo
    }

}
