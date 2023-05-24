using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoMovible : MonoBehaviour
{
    private float velocidad = 5f; // Velocidad de movimiento del objeto


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // Obt�n el movimiento horizontal del mouse
        float mouseY = Input.GetAxis("Mouse Y"); // Obt�n el movimiento vertical del mouse

        Vector3 movement = new Vector3(mouseX, 0f, mouseY) * velocidad * Time.deltaTime; // Calcula el vector de movimiento

        transform.Translate(movement); // Mueve el objeto en la direcci�n calculada
    }
}
