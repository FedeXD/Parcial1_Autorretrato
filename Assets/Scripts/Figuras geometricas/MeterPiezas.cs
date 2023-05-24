using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterPiezas : MonoBehaviour
{
    BrazoMovible brazo;

    private void Start()
    {
        brazo = GameObject.FindObjectOfType<BrazoMovible>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        FixedJoint fixedJoint = brazo.GetComponent<FixedJoint>();
        if (other.gameObject.CompareTag("Figura"))
        {
            Destroy(other.gameObject);
            Destroy(fixedJoint);
        }
    }
}
