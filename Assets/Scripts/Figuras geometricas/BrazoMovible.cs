using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoMovible : MonoBehaviour
{
    private float velocidad = 5f; //Velocidad de movimiento del objeto
    private Vector3 posicionInicial;
    private bool clicSostenido = false; //Indica si se est� sosteniendo el clic
    private static FixedJoint fixedJoint; // Componente FixedJoint para mantener la conexi�n
    private bool agarrando = false; // Indica si est�s agarrando el objeto
    private static Rigidbody rb;

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
            if (clicSostenido) //Si se solt� el clic, se mueve el objeto a la posici�n inicial
            {
                clicSostenido = false;
                rb.MovePosition(posicionInicial); 
            }
        }
       

        rb.MovePosition(rb.position + movement); //Mueve el objeto 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!agarrando && collision.gameObject.CompareTag("Figura"))
        {
            agarrando = true;

            // Desactiva la gravedad y la detecci�n de colisiones para evitar interacciones f�sicas no deseadas
            rb.useGravity = false;

            // Crea y configura el FixedJoint
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;

            rb.MovePosition(posicionInicial);
        }
    }
}
