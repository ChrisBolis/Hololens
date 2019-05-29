using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour, IInputClickHandler, IFocusable
{
    [SerializeField] GameObject UIStart;

    AudioSource audio;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(MacchinarioController.isSwitchOn)
        {
            Debug.Log("Acceso!");
            MacchinarioController.isWorking = true;
            UIStart.SetActive(false);
        }

        audio.Play();
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
