using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezzoController : MonoBehaviour
{
    [SerializeField] GameObject caricatore;
    [HideInInspector] public static int pezziCaricati = 0;
    [SerializeField] GameObject Pannello;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colpito!");
        if(collision.gameObject.tag == "Caricatore")
        {
            Debug.Log("Caricato!");
            transform.position = caricatore.GetComponent<Transform>().position;

            transform.position = new Vector3(transform.position.x, transform.position.y + (gameObject.GetComponent<Renderer>().bounds.size.y + 0.003f) * pezziCaricati, transform.position.z);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            pezziCaricati++;
            Debug.Log($"Pezzi caricati: {pezziCaricati}");
            transform.rotation = collision.gameObject.GetComponentInChildren<Transform>().rotation;

            Pannello.GetComponent<PannelloController>().LoadPezzo();
        }
    }
}
