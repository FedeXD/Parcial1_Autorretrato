using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCubo : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del cubo
    public float jumpForce = 5f;         // Fuerza de salto del cubo
    public bool canJump = true;          // Indicador de si el cubo puede saltar
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener referencia al componente Rigidbody
    }

    private void Update()
    {
        if (canJump && Input.GetKeyDown(KeyCode.W))  // Si el cubo puede saltar y se presiona el botón de salto
        {
            Jump();  // Llamar a la función de salto
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Obtener la entrada horizontal del jugador

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f); // Crear un vector de movimiento

        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, 0f);  // Aplicar la velocidad al Rigidbody del cubo, conservando la velocidad vertical
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Aplicar una fuerza hacia arriba al cubo para el salto
        canJump = false;  // Deshabilitar el salto hasta que el cubo vuelva a tocar el suelo
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))  // Verificar si el cubo colisiona con el suelo
        {
            canJump = true;  // Habilitar el salto cuando el cubo toca el suelo
        }
    }
}
