using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/************************************* CONTROLLER PER LA GESTIONE DEL BLOCCO ARIA *************************************/

public class Aria : MonoBehaviour, IInputClickHandler, IFocusable
{
    // Classe master a cui fanno riferimento tutti i GameObject ricorrenti
    [SerializeField] GameObject masterController;

    // Campi riservati a questo script
    [SerializeField] GameObject statusUI, text;
    [SerializeField] float interval = 0.5f;
    [SerializeField] string defaultMsg = "Pressione regolare";

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
        SceneController.isAirError = false;
        
        // ...e sistema l'interfaccia
        text.GetComponent<TextMesh>().text = defaultMsg;
        master.errorUI.SetActive(false);
    }

    public void OnFocusEnter()
    {
        isFocused = true;
        StartCoroutine(ShowInterface());
    }

    public void OnFocusExit()
    {
        isFocused = false;
        StartCoroutine(HideInterface());
    }

    // Metodi per la visualizzazione del tooltip
    IEnumerator ShowInterface()
    {
        yield return new WaitForSeconds(interval);

        if (isFocused)
            statusUI.SetActive(true);
    }

    IEnumerator HideInterface()
    {
        yield return new WaitForSeconds(interval);

        if (!isFocused)
            statusUI.SetActive(false);
    }
}
