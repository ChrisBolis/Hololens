using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************* CONTROLLER PER LA GESTIONE DELLA LOGICA DI FUNZIONAMENTO DEL MACCHINARIO *************************************/

public class SceneController : MonoBehaviour
{
    // Classe master a cui fanno riferimento tutti i GameObject ricorrenti
    [SerializeField] GameObject masterController;

    public int interval = 5;

    // Variabili globali che controllano lo stato del macchinario
    public static bool isWorking = false, isSwitchOn = false, isAirError = false, isPowerError = false;

    // Campi riservati a questo script
    MasterController master;
    public static AudioSource usePieceSound;

    bool isStarted = false;

    void Start()
    {
        master = masterController.GetComponent<MasterController>();
        usePieceSound = master.loader.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSwitchOn)
            ShutDown();

        if ((MasterController.loadedPieces <= 0 || isPowerError || isAirError) && isWorking)
            GenerateError();

        else if (isWorking && !isStarted)
            StartCoroutine(UsePiece());
    }

    IEnumerator UsePiece()
    {
        isStarted = true;
        master.switchLight(false);

        yield return new WaitForSeconds(interval);

        PezzoController.ScaricaPezzo();
        usePieceSound.Play();

        int extracted = Random.Range(1, 100);

        // Generazione errore (40%)...
        if (extracted > 0 && extracted <= 41)
        {
            master.errorUI.SetActive(true);

            //...Errore aria (20%)
            if (extracted > 0 && extracted <= 20)
            {
                isAirError = true;
                master.airStatus.GetComponent<TextMesh>().text = master.airErrorMsg;
                master.airPieceArrow.SetActive(true);
            }

            // ...Errore centralina (20%)
            else if (extracted > 20 && extracted <= 41)
            {
                isPowerError = true;
                master.powerStatus.GetComponent<TextMesh>().text = master.powerErrorMsg;
                master.powerPieceArrow.SetActive(true);
            }
        }

        isStarted = false;
    }

    //********** METODI PRIVATI **********

    void GenerateError()
    {
        master.switchLight(true);
        isWorking = false;

        isStarted = false;
    }

    void ShutDown()
    {
        isWorking = false;
        isStarted = false;
        master.switchLight(false);

        StopAllCoroutines();
    }
}