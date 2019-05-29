using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezzoController : MonoBehaviour
{
    [SerializeField] GameObject caricatore;
    //[SerializeField] GameObject Pannello;
    [SerializeField] GameObject UIPezzi;

    [HideInInspector] public static int pezziCaricati = 0;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Caricatore")
        {
            Debug.Log("Caricato!");
            transform.position = caricatore.GetComponent<Transform>().position;

            transform.position = new Vector3(transform.position.x, transform.position.y + (gameObject.GetComponent<Renderer>().bounds.size.y + 0.003f) * pezziCaricati, transform.position.z);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            pezziCaricati++;
            Debug.Log($"Pezzi caricati: {pezziCaricati}");
            transform.rotation = collision.gameObject.GetComponentInChildren<Transform>().rotation;

            gameObject.GetComponent<HandDraggable>().enabled = false;
            //Pannello.GetComponent<PannelloController>().LoadPezzo();
        }

        if (pezziCaricati <= 0)
            UIPezzi.SetActive(true);

        else
            UIPezzi.SetActive(false);
    }
}
