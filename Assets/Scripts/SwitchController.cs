using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************* CONTROLLER DELL'INTERRUTTORE PRINCIPALE D'ACCENSIONE *************************************/

public class SwitchController : MonoBehaviour, IInputClickHandler, IFocusable
{
    // Classe master a cui fanno riferimento tutti i GameObject ricorrenti
    [SerializeField] GameObject masterController;

    // Campi riservati a questo script
    [SerializeField] GameObject switchLever;
    [SerializeField] float rotation = 45f;

    MasterController master;
    AudioSource sound;

    void Start()
    {
        master = masterController.GetComponent<MasterController>();
        sound = gameObject.GetComponent<AudioSource>();
    }

    // Quando l'utente tappa sull'oggetto...
    public void OnInputClicked(InputClickedEventData eventData)
    {
        actionSwitch(SceneController.isSwitchOn);
        sound.Play();
    }

    public void OnFocusEnter() { /*throw new System.NotImplementedException();*/ }
    public void OnFocusExit() { /*throw new System.NotImplementedException();*/ }

    //********** METODI PRIVATI **********

    // Metodo responsabile della logica dell'interruttore
    void actionSwitch(bool isActivated)
    {
        float angleOfRotation = rotation;

        if (isActivated)
            angleOfRotation = -angleOfRotation;

        // Ruota l'interruttore
        switchLever.transform.Rotate(new Vector3(0f, 0f, angleOfRotation), Space.Self);

        // Agisci sull'interfaccia
        master.switchUI.SetActive(isActivated);
        master.startUI.SetActive(!isActivated);

        // Comunica i cambiamenti al manager
        SceneController.isSwitchOn = !SceneController.isSwitchOn;
    }
}