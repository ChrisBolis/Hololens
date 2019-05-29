using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour, IInputClickHandler, IFocusable
{
    [SerializeField] GameObject manopola;
    [SerializeField] GameObject UISwitch;
    [SerializeField] GameObject UIStart;


    [SerializeField] float rotation = 35f;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Cliccato");

        if(!MacchinarioController.isSwitchTurned)
        {
            manopola.transform.Rotate(new Vector3(0f, 0f, rotation), Space.Self);
            MacchinarioController.isSwitchTurned = true;

            UISwitch.SetActive(false);
            UIStart.SetActive(true);
        }

        else
        {
            manopola.transform.Rotate(new Vector3(0f, 0f, -rotation), Space.Self);
            MacchinarioController.isSwitchTurned = false;

            UISwitch.SetActive(true);
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
