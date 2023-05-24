using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoQueVuela : MonoBehaviour
{
    public Transform player;
    public float velocidadMovimiento = 5f;
    public float distanciaRaycast = 2f;
    public float radioDeteccion = 10f;
    public float velocidadProyectil = 1f; 
    public GameObject[] prefabProyectil;//Prefabs de proyectiles
    public Transform proyectilPuntoOrigen;//Punto de origen del proyectil

    private float tiempoProyectil; //Cada cuanto tiempo dispara de nuevo

    private void Update()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccionHaciaElJugador = player.position - transform.position;
            direccionHaciaElJugador.y = 0f; //Asegura que el enemigo se mantenga a la misma altura

            // Calcula la distancia entre el enemigo y el jugador
            float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

            //Se fija si hay obstáculos en la dirección hacia el jugador
            
            if(distanciaAlJugador <= radioDeteccion)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direccionHaciaElJugador, out hit, distanciaRaycast))
                {
                    // Si hay un obstáculo, calcula una nueva dirección evitando el obstáculo
                    Vector3 esquivar = Vector3.Reflect(direccionHaciaElJugador, hit.normal).normalized;
                    transform.Translate(esquivar * velocidadMovimiento * Time.deltaTime);
                }
                else //Si no hay obstáculos, sigue persiguiendo al jugador
                {
                    transform.LookAt(player);
                    transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);
                }

                // Disparar si ha pasado el tiempo de disparo
                tiempoProyectil += Time.deltaTime;
                if (tiempoProyectil >= 4f / velocidadProyectil)
                {
                    DispararProyectil();
                    tiempoProyectil = 0f;
                }
            }                   
        }
    }

    private void DispararProyectil()
    {
        if (prefabProyectil != null && prefabProyectil.Length > 0 && proyectilPuntoOrigen != null)
        {
            // Elige un prefab de proyectil al azar
            GameObject randomProjectilePrefab = prefabProyectil[Random.Range(0, prefabProyectil.Length)];

            // Crea un nuevo proyectil
            GameObject projectile = Instantiate(randomProjectilePrefab, proyectilPuntoOrigen.position, Quaternion.identity);

            // Orienta el proyectil hacia el jugador
            Vector3 directionToPlayer = (player.position - projectile.transform.position).normalized;
            projectile.transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }
}
