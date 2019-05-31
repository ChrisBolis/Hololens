using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/************************************* CONTROLLER PER LA GESTIONE DELLA CENTRALINA *************************************/

public class Centralina : MonoBehaviour, IInputClickHandler, IFocusable
{
    // Classe master a cui fanno riferimento tutti i GameObject ricorrenti
    [SerializeField] GameObject masterController;

    // Campi riservati a questo script
    [SerializeField] GameObject UIStato, testo;
    [SerializeField] float interval = 0.5f;
    [SerializeField] string messaggioDefault = "In funzione";

    MasterController master;
    bool isFocused = false;

    void Start()
    {
        master = masterController.GetComponent<MasterController>();
    }

    // Quando l'utente tappa sull'oggetto...
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // ...risolvi l'errore...
        SceneController.isPowerError = false;

        // ...e sistema l'interfaccia
        testo.GetComponent<TextMesh>().text = messaggioDefault;
        master.errorUI.SetActive(false);
        master.powerPieceArrow.SetActive(false);
    }

    public void OnFocusEnter()
    {
        isFocused = true;
        StartCoroutine(MostraInterfaccia());
    }

    public void OnFocusExit()
    {
        isFocused = false;
        StartCoroutine(NascondiInterfaccia());
    }

    // Metodi per la visualizzazione del tooltip
    IEnumerator MostraInterfaccia()
    {
        yield return new WaitForSeconds(interval);

        if (isFocused)
            UIStato.SetActive(true);
    }

    IEnumerator NascondiInterfaccia()
    {
        yield return new WaitForSeconds(interval);

        if (!isFocused)
            UIStato.SetActive(false);

    }
}
