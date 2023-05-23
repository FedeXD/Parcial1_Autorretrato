using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElegirLaLetra : MonoBehaviour
{
    public Text letraText;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            letraText.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }    
    }


}
