using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************* CONTROLLER PER LA GESTIONE DEL TASTO START *************************************/

public class StartController : MonoBehaviour, IInputClickHandler, IFocusable
{
    // Classe master a cui fanno riferimento tutti i GameObject ricorrenti
    [SerializeField] GameObject masterController;

    MasterController master;
    AudioSource audio;

    void Start()
    {
        master = masterController.GetComponent<MasterController>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(SceneController.isSwitchOn)
        {
            SceneController.isWorking = true;
            master.startUI.SetActive(false);
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
