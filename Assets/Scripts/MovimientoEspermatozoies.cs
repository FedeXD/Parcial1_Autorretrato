using System.Collections.Generic;
using UnityEngine;

public class MovimientoEspermatozoies : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float velocidadInicial = 2;
    public float incrementoVelocidad = 0.5f;
    int index = 0;
    public bool seRepite;
    private float velocidadActual;


    private void Start()
    {
        velocidadActual = velocidadInicial;
        InvokeRepeating(nameof(AumentarVelocidad), 10f, 10f);
    }

    private void AumentarVelocidad()
    {
        velocidadActual += incrementoVelocidad; // Incrementar la velocidad
    }

    private void Update()
    {
        Vector3 destino = waypoints[index].transform.position;
        Vector3 siguientePosicion = Vector3.MoveTowards(transform.position, destino, velocidadActual * Time.deltaTime);
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
                if (seRepite)
                {
                    index = 0;
                }
            }
        }

        
    }
}
