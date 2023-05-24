using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoMovible : MonoBehaviour
{
    private float velocidad = 5f; //Velocidad de movimiento del objeto
    private Vector3 posicionInicial;
    private bool clicSostenido = false; //Indica si se está sosteniendo el clic
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); 
        float mouseY = Input.GetAxis("Mouse Y"); 

        Vector3 movement = new Vector3(mouseX, 0f, mouseY) * velocidad * Time.deltaTime; //Calcula el vector de movimiento

        if (Input.GetMouseButton(0)) //Si se mantiene el click izquierdo del mouse
        {
            clicSostenido = true;
            movement += Vector3.down * velocidad * Time.deltaTime; //Le da movimiento hacia abajo si se sostiene el click
        }
        else
        {
            if (clicSostenido) //Si se soltó el clic, se mueve el objeto a la posición inicial
            {
                clicSostenido = false;
                rb.MovePosition(posicionInicial); 
            }
        }

        rb.MovePosition(rb.position + movement); //Mueve el objeto 
    }

}
