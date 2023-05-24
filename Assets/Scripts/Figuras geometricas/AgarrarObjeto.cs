using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    private bool agarrando = false; // Indica si estás agarrando el objeto
    private Rigidbody rb;
    private FixedJoint fixedJoint; // Componente FixedJoint para mantener la conexión
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!agarrando && collision.gameObject.CompareTag("Figura"))
        {
            agarrando = true;

            // Desactiva la gravedad y la detección de colisiones para evitar interacciones físicas no deseadas
            rb.useGravity = false;
            rb.isKinematic = true;

            // Crea y configura el FixedJoint
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;
        }
    }

    void Update()
    {
        if (agarrando && Input.GetMouseButtonDown(1)) // Puedes definir cualquier tecla para liberar el objeto
        {
            agarrando = false;

            // Reactiva la gravedad y la detección de colisiones
            rb.useGravity = true;
            rb.isKinematic = false;

            // Destruye el FixedJoint para liberar el objeto
            Destroy(fixedJoint);
        }
    }


    
}
