using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezzoController : MonoBehaviour
{
    [SerializeField] GameObject caricatore;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject UIPezzi;

    [HideInInspector] public static int pezziCaricati = 0;

    static GameObject[] elencoPezzi = new GameObject[13];

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Caricatore" && pezziCaricati <= 13)
        {
            Debug.Log("Caricato!");

            transform.position = new Vector3(caricatore.transform.position.x, caricatore.transform.position.y + (transform.lossyScale.y + 0.001f) * pezziCaricati, caricatore.transform.position.z);
            transform.rotation = collision.gameObject.GetComponentInChildren<Transform>().rotation;

            Instantiate(gameObject, spawner.transform.position, spawner.transform.rotation);

            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<HandDraggable>().enabled = false;

            elencoPezzi[pezziCaricati] = gameObject;
            pezziCaricati++;

            Debug.Log($"Pezzi caricati: {pezziCaricati}");
        }

        if (pezziCaricati <= 0)
            UIPezzi.SetActive(true);

        else
            UIPezzi.SetActive(false);
    }

    public static int ScaricaPezzo()
    {
        if (pezziCaricati > 0)
        {
            Destroy(elencoPezzi[pezziCaricati - 1]);
            pezziCaricati--;

            SceneController.audio.Play();
        }

        return pezziCaricati;
    }
}