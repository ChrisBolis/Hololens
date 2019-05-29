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

    AudioSource audio;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Cliccato");

        if(!MacchinarioController.isSwitchOn)
        {
            manopola.transform.Rotate(new Vector3(0f, 0f, rotation), Space.Self);
            MacchinarioController.isSwitchOn = true;

            UISwitch.SetActive(false);
            UIStart.SetActive(true);

            audio.Play();
        }

        else
        {
            manopola.transform.Rotate(new Vector3(0f, 0f, -rotation), Space.Self);
            MacchinarioController.isSwitchOn = false;
            MacchinarioController.isWorking = false;

            UIStart.SetActive(false);
            UISwitch.SetActive(true);

            audio.Play();
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
