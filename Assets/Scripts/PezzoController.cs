using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************* CONTROLLER PER LA GESTIONE DELLA LOGICA DEI PEZZI *************************************/

public class PezzoController : MonoBehaviour
{
    // Classe master a cui fanno riferimento tutti i GameObject ricorrenti
    [SerializeField] GameObject masterController;

    // Campi riservati a questo script
    MasterController master;
    static GameObject[] piecesArray = new GameObject[13];

    void Start()
    {
        master = masterController.GetComponent<MasterController>();
    }

    void Update()
    {
        // Se il pezzo meccanico cade troppo in basso...
        if (Vector3.Distance(gameObject.transform.position, master.spawner.transform.position) > 10f && !gameObject.GetComponent<HandDraggable>().isDragging)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; // ...fermalo...
            gameObject.transform.position = master.spawner.transform.position; // ...e riportalo allo spawner
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Caricatore" && MasterController.loadedPieces <= 13)
        {
            // Crea un nuovo pezzo
            Instantiate(gameObject, master.spawner.transform.position, master.spawner.transform.rotation);

            loadPiece();
        }
    }

    //********** METODI PUBBLICI **********

    public static void ScaricaPezzo()
    {
        if (MasterController.loadedPieces > 0)
        {
            Destroy(piecesArray[MasterController.loadedPieces - 1]);
            MasterController.loadedPieces--;
        }
    }

    //********** METODI PRIVATI **********

    void loadPiece()
    {
        // Posiziona il pezzo nel macchinario...
        transform.position = new Vector3(master.loader.transform.position.x, master.loader.transform.position.y + (transform.lossyScale.y + 0.001f) * MasterController.loadedPieces, 
            master.loader.transform.position.z);
        transform.rotation = master.loader.GetComponent<Transform>().rotation;

        // ...disattiva la fisica
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<HandDraggable>().enabled = false;

        // ...e registralo
        piecesArray[MasterController.loadedPieces] = gameObject;
        MasterController.loadedPieces++;
        if (!master.loadedPiece)
        {
            master.switchArrow.SetActive(true);
            master.switchUI.SetActive(true);
            master.loadedPiece = true;
        }

        // Disattiva il pannello dell'UI
        master.piecesUI.SetActive(false);
        master.pieceArrow.SetActive(false);
    }
}