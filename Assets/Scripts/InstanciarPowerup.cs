using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPowerup : MonoBehaviour
{
    public GameObject powerupPrefab; // Asigna el prefab del power-up en el Inspector
    private void GenerarPowerUp()
    {
        // Genera una posición aleatoria en el eje X
        float randomX = Random.Range(-25f, 25f); // Ajusta los límites de acuerdo a tus necesidades

        // Genera la posición final para el power-up
        Vector3 posicionDeSpawn = new Vector3(randomX, 0f, 0f); // Ajusta la posición en los ejes Y y Z según tus necesidades

        // Instancia el power-up en la posición generada
        Instantiate(powerupPrefab, posicionDeSpawn, Quaternion.identity);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GenerarPowerUp), 0f, 20f);
    }
}
