using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezzoReplacer : MonoBehaviour
{
    [SerializeField] MasterController masterController;
    private void OnTriggerEnter(Collider other)
    {
        var pezzo = other.GetComponent<PezzoController>();
        if (pezzo)
        {
            pezzo.transform.position = masterController.spawner.transform.position;
            pezzo.transform.rotation = masterController.spawner.transform.rotation;
            if (pezzo.GetComponent<Rigidbody>())
            {
                pezzo.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
