using System.Collections.Generic;
using UnityEngine;

public class MovimientoEspermatozoies : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float velocidadInicial = 2;
    public float incrementoVelocidad = 0.5f;
    public float distanciaDeteccion = 2f; // Distancia para detectar otros espermatozoides
    public float distanciaEvasion = 3f; // Distancia para evadir otros espermatozoides
    public float evasionForce = 10f; // Fuerza de evasión
    public List<MostrarGanaste> mostrarGanaste;
    int index = 0;
    private float velocidadActual;
    private void Start()
    {
        velocidadActual = velocidadInicial;
        InvokeRepeating(nameof(AumentarVelocidad), 10f, 10f);
        foreach (MostrarGanaste elemento in mostrarGanaste)
        {
            elemento.Ocultar();
        }
    }

    private void AumentarVelocidad()
    {
        velocidadActual += incrementoVelocidad; // Incrementar la velocidad
    }

    private void Update()
    {
        Vector3 destino = waypoints[index].transform.position;
        Vector3 siguientePosicion = Vector3.MoveTowards(transform.position, destino, velocidadActual * Time.deltaTime);

        // Comprobar si hay otros espermatozoides cercanos
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanciaDeteccion);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Espermatozoide") && collider.gameObject != gameObject)
            {
                // Calcular la dirección para evadir al otro espermatozoide
                Vector3 evasionDirection = (transform.position - collider.transform.position).normalized;

                // Aplicar fuerza para evadir
                GetComponent<Rigidbody>().AddForce(evasionDirection * evasionForce, ForceMode.Acceleration);
            }
        }

        transform.position = siguientePosicion;

        float distancia = Vector3.Distance(transform.position, destino);
        if(distancia <= 0.05)
        {
            if(index < waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                foreach (MostrarGanaste elemento in mostrarGanaste)
                {
                    elemento.Mostrar();
                }
            }
        }

        
    }
}
