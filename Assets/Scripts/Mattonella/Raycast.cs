using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************* SCRIPT PER IL POSIZIONAMENTO DELLA MATTONELLA *************************************/

public class Raycast : MonoBehaviour
{
    [SerializeField] GameObject mattonella;

    void FixedUpdate()
    {
        if (mattonella == null)
            return;

        RaycastHit hit;

        Vector3 vet3 = transform.TransformDirection(Vector3.forward) * 10;

        if (Physics.Raycast(transform.position, (vet3), out hit))
        {
            mattonella.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            mattonella.transform.rotation = new Quaternion(mattonella.transform.rotation.x, transform.rotation.y, mattonella.transform.rotation.z, transform.rotation.w);
        }
    }
}

