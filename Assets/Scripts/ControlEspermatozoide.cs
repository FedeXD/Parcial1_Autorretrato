using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEspermatozoide : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del objeto
    private bool isDragging = false; // Indica si se est� arrastrando el objeto
    public float rotationSpeed = 10f; // Velocidad de rotaci�n del objeto
    private Vector3 initialMousePosition; // Posici�n inicial del cursor al hacer clic
    private Rigidbody rb; // Referencia al componente Rigidbody del objeto

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calcula la rotaci�n basada en la direcci�n del movimiento
        if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            isDragging = true; // Comienza el arrastre
            initialMousePosition = Input.mousePosition; // Guarda la posici�n inicial del cursor
        }
        else if (Input.GetMouseButtonUp(0)) // Si se suelta el clic izquierdo
        {
            isDragging = false; // Finaliza el arrastre
        }

        if (isDragging) // Si se est� arrastrando
        {
            Vector3 mouseDelta = Input.mousePosition - initialMousePosition; // Calcula el cambio de posici�n del cursor

            // Calcula la direcci�n de movimiento basada en la posici�n del cursor
            Vector3 movementDirection = new Vector3(mouseDelta.x, 0, mouseDelta.y).normalized;

            // Aplica la velocidad y direcci�n al Rigidbody del objeto
            rb.velocity = movementDirection * speed;

            // Calcula la rotaci�n basada en la direcci�n del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

            // Interpola suavemente la rotaci�n actual hacia la rotaci�n objetivo
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero; // Detiene el movimiento si no se est� arrastrando
        }

        

    }
}
