using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour, IInputClickHandler, IFocusable
{
    [SerializeField] GameObject UIStart;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(MacchinarioController.isSwitchTurned)
        {
            Debug.Log("Acceso!");
            MacchinarioController.isOn = true;
            UIStart.SetActive(false);
        }
    }

    public void OnFocusEnter()
    {
        //throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        //throw new System.NotImplementedException();
    }

}
