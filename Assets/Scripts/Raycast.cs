using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HololensProject
{
    public class Raycast : MonoBehaviour
    {
        [SerializeField] GameObject Mattonella;

        void FixedUpdate()
        {
            if (Mattonella == null)
                return;
            RaycastHit hit;

            Vector3 vet3 = transform.TransformDirection(Vector3.forward) * 10;

            if (Physics.Raycast(transform.position, (vet3), out hit))
            {
                Mattonella.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                Mattonella.transform.rotation = new Quaternion(Mattonella.transform.rotation.x, this.transform.rotation.y, Mattonella.transform.rotation.z, this.transform.rotation.w);
            }
        }
    }
}

