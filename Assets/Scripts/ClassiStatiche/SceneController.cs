using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public int interval = 5;

    // Variabile globali che controllano lo stato del macchinario
    public static bool isWorking = false;
    public static bool isSwitchOn = false;
    public static bool isErrorAria = false;
    public static bool isErrorCentralina = false;
    //public static bool isError = false;

    [SerializeField] GameObject alarmLight, UIPezzi;
    [SerializeField] GameObject caricatore;

    //pannello di errore generale
    [SerializeField] GameObject UIErrori;

    [SerializeField] GameObject statoAria;
    [SerializeField] string messaggioErroreAria = "Pressione aria troppo bassa";

    [SerializeField] GameObject statoCentralina;
    [SerializeField] string messaggioErroreCentralina = "Malfunzionamento interno";

    public static AudioSource audio;

    bool coRoutineStarted = false;

    void Start()
    {
        audio = caricatore.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking && isSwitchOn && PezzoController.pezziCaricati <= 0 && coRoutineStarted)
        {
            StopCoroutine(ConsumaPezzi());

            alarmLight.SetActive(true);

            isWorking = false;
            coRoutineStarted = false;
        }

        if ((isWorking && PezzoController.pezziCaricati > 0 && alarmLight.activeSelf) || !isSwitchOn)
            alarmLight.SetActive(false);

        else if (isWorking && !coRoutineStarted && !isErrorCentralina && !isErrorAria)
        {
            StartCoroutine(ConsumaPezzi());

            coRoutineStarted = true;
        }

        else if (PezzoController.pezziCaricati <= 0)
            UIPezzi.SetActive(true);
    }

    IEnumerator ConsumaPezzi()
    {
        while (isWorking && !isErrorAria && !isErrorCentralina)
        {
            yield return new WaitForSeconds(interval);

            bool IsFinished = PezzoController.ScaricaPezzo() == 0;

            int extracted = Random.Range(1, 100);
            Debug.Log(extracted);
            //generazione errore 40% possibilità totale errore...
            if (extracted > 0 && extracted <= 41)
            {
                alarmLight.SetActive(true);
                UIErrori.SetActive(true);

                coRoutineStarted = false;
                isWorking = false;

                //...20% aria
                if (extracted > 0 && extracted <= 20)
                {
                    statoAria.GetComponent<TextMesh>().text = messaggioErroreAria;
                    isErrorAria = true;
                    
                }
                // ...20% centralina
                else if (extracted > 20 && extracted <= 41)
                {
                    statoCentralina.GetComponent<TextMesh>().text = messaggioErroreCentralina;
                    isErrorCentralina = true;    
                }

                StopCoroutine(ConsumaPezzi());
            }

            if(IsFinished)
            {
                alarmLight.SetActive(true);
                UIPezzi.SetActive(true);

                coRoutineStarted = false;
                isWorking = false;

                StopCoroutine(ConsumaPezzi());
            }
        }
    }

    //public void SolveErrors()
    //{
    //    isError = false;
    //    UIErrori.SetActive(false);
    //    statoAria.GetComponent<TextMesh>().text = messaggioDefaultAria;
    //    //statoCentralina.GetComponent<TextMesh>().text = messaggioDefaultCentralina;
    //}
}