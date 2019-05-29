using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacchinarioController : MonoBehaviour
{
    public int interval = 5;

    // Variabile globali che controllano lo stato del macchinario
    public static bool isWorking = false;
    public static bool isSwitchOn = false;

    [SerializeField] GameObject alarmLight;
    [SerializeField] GameObject caricatore;

    AudioSource audio;
    bool coRoutineStarted = false;

    void Start()
    {
        audio = caricatore.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWorking && isSwitchOn && PezzoController.pezziCaricati <= 0 && !alarmLight.activeSelf)
        {
            StopCoroutine(ConsumaPezzi());

            alarmLight.SetActive(true);

            isWorking = false;
            coRoutineStarted = false;
        }

        if ((isWorking && PezzoController.pezziCaricati > 0 && alarmLight.activeSelf) || !isSwitchOn)
            alarmLight.SetActive(false);

        else if (isWorking && !coRoutineStarted)
        {
            StartCoroutine(ConsumaPezzi());

            coRoutineStarted = true;
        }
    }

    IEnumerator ConsumaPezzi()
    {
        while(isWorking)
        {
            yield return new WaitForSeconds(interval);

            int extracted = Random.Range(1, 100);

            PezzoController.ScaricaPezzo();
            audio.Play();

            if(extracted > 0 && extracted <= 20)
            {
                // TO-DO: Generare errore aria
            }

            else if(extracted > 20 && extracted <= 41)
            {
                // TO-DO: Generare errore centralina
            }
        }
    }
}