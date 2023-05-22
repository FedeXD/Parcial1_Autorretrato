using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEspermatozoide : MonoBehaviour
{
    public float velocidad = 5f; //Velocidad de movimiento del objeto
    private bool estaArrastrandose = false; //Indica si el objeto se est� arrastrando
    public float rotacionVelocidad = 10f; //Velocidad de rotaci�n del objeto
    private Vector3 posicionInicialCursor; //Posici�n inicial del cursor al hacer clic
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Calcula la rotaci�n basada en la direcci�n del movimiento
        if (Input.GetMouseButtonDown(0)) //Si se hace clic izquierdo
        {
            estaArrastrandose = true; 
            posicionInicialCursor = Input.mousePosition; //Guarda la posici�n inicial del cursor
        }
        else if (Input.GetMouseButtonUp(0)) //Si se suelta el clic izquierdo
        {
            estaArrastrandose = false; 
        }

        if (estaArrastrandose) // Si se est� arrastrando
        {
            Vector3 mouseDelta = Input.mousePosition - posicionInicialCursor; // Calcula el cambio de posici�n del cursor

            //Calcula la direcci�n de movimiento dependiendo de la posici�n del cursor
            Vector3 movementDirection = new Vector3(mouseDelta.x, 0, mouseDelta.y).normalized;

            //Aplica la velocidad y direcci�n al Rigidbody del objeto
            rb.velocity = movementDirection * velocidad;

            //Calcula la rotaci�n basada en la direcci�n del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

            //Interpola suavemente la rotaci�n actual hacia la rotaci�n objetivo
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotacionVelocidad * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero; //Detiene el movimiento si no se est� arrastrando
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) 
        {
            velocidad += 2f;
            Destroy(other.gameObject);
        }
    }
}
