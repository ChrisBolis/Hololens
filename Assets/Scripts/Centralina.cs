using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Centralina : MonoBehaviour, IInputClickHandler, IFocusable
{
    [SerializeField] GameObject Pannello;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Centralina");
        Pannello.GetComponent<PannelloController>().CheckCentralina();

        //eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
    }

    public void OnFocusEnter()
    {
        //throw new NotImplementedException();
    }

    public void OnFocusExit()
    {
        //throw new NotImplementedException();
    }
    
}
