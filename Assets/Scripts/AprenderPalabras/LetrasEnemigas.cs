using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetrasEnemigas : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("Enemigo") && collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
