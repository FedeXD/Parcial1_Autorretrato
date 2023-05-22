using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEspermatozoide : MonoBehaviour
{
    public float velocidad = 5f; //Velocidad de movimiento del objeto
    private bool estaArrastrandose = false; //Indica si el objeto se está arrastrando
    public float rotacionVelocidad = 10f; //Velocidad de rotación del objeto
    private Vector3 posicionInicialCursor; //Posición inicial del cursor al hacer clic
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Calcula la rotación basada en la dirección del movimiento
        if (Input.GetMouseButtonDown(0)) //Si se hace clic izquierdo
        {
            estaArrastrandose = true; 
            posicionInicialCursor = Input.mousePosition; //Guarda la posición inicial del cursor
        }
        else if (Input.GetMouseButtonUp(0)) //Si se suelta el clic izquierdo
        {
            estaArrastrandose = false; 
        }

        if (estaArrastrandose) // Si se está arrastrando
        {
            Vector3 mouseDelta = Input.mousePosition - posicionInicialCursor; // Calcula el cambio de posición del cursor

            //Calcula la dirección de movimiento dependiendo de la posición del cursor
            Vector3 movementDirection = new Vector3(mouseDelta.x, 0, mouseDelta.y).normalized;

            //Aplica la velocidad y dirección al Rigidbody del objeto
            rb.velocity = movementDirection * velocidad;

            //Calcula la rotación basada en la dirección del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

            //Interpola suavemente la rotación actual hacia la rotación objetivo
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotacionVelocidad * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero; //Detiene el movimiento si no se está arrastrando
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
