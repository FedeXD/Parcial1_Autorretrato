using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPowerup : MonoBehaviour
{
    public GameObject powerupPrefab; // Asigna el prefab del power-up en el Inspector
    private void GenerarPowerUp()
    {
        // Genera una posici�n aleatoria en el eje X
        float randomX = Random.Range(-25f, 25f); // Ajusta los l�mites de acuerdo a tus necesidades

        // Genera la posici�n final para el power-up
        Vector3 posicionDeSpawn = new Vector3(randomX, 0f, 0f); // Ajusta la posici�n en los ejes Y y Z seg�n tus necesidades

        // Instancia el power-up en la posici�n generada
        Instantiate(powerupPrefab, posicionDeSpawn, Quaternion.identity);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GenerarPowerUp), 0f, 20f);
    }
}
