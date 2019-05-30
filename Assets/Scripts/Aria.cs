using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Aria : MonoBehaviour, IInputClickHandler, IFocusable
{
    [SerializeField] GameObject UIStato, testo, UIErrore;
    [SerializeField] float interval = 0.5f;

    [SerializeField] string messaggioDefault = "Pressione regolare";

    //[SerializeField] GameObject statoAria;
    //[SerializeField] string messaggioDefaultAria = "Pressione regolare";


    bool isFocused = false;
    
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Aria");
        SceneController.isErrorAria = false;

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
