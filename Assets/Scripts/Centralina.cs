using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Centralina : MonoBehaviour, IInputClickHandler, IFocusable
{
    [SerializeField] GameObject UIStato, testo, UIErrore;
    [SerializeField] float interval = 0.5f;
    [SerializeField] string messaggioDefault = "In funzione";

    bool isFocused = false;

    //[SerializeField] GameObject statoCentralina;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Centralina");
        SceneController.isErrorCentralina = false;

        testo.GetComponent<TextMesh>().text = messaggioDefault;

        UIErrore.SetActive(false);
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
