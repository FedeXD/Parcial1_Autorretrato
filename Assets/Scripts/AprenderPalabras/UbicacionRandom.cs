using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbicacionRandom : MonoBehaviour
{
    public Vector2 posicionNegativa;
    public Vector2 posicionPositiva;
    void Start()
    {
        Vector2 posicionRandom = new Vector2(Random.Range(-posicionNegativa.x, posicionPositiva.x), Random.Range(-posicionNegativa.y, posicionPositiva.y));

        transform.position = posicionRandom;
    }
}

