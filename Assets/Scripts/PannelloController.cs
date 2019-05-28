using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class PannelloController : MonoBehaviour
{
    [SerializeField] GameObject testoCompletato;
    [SerializeField] GameObject smcModel;

    [SerializeField] GameObject bool1;
    [SerializeField] GameObject bool2;
    [SerializeField] GameObject bool3;

    bool AriaChecked = false;
    bool CentralinaChecked = false;
    bool displayed = false;


    private void Start()
    {
        transform.parent.parent = smcModel.transform;
        transform.parent.localPosition = new Vector3(0, 1.7f, 0);
        transform.parent.parent = null;
    }
    void Update()
    {
        if(PezzoController.pezziCaricati >= 3 && AriaChecked && CentralinaChecked && !displayed)
        {
            Debug.Log("Finito");
            testoCompletato.SetActive(true);
            displayed = true;
        }
    }

    public void LoadPezzo()
    {        
        Debug.Log("Pannello: Pezzo");
        bool1.GetComponent<TextMesh>().text = "ANCORA " + (3-PezzoController.pezziCaricati);

        if (PezzoController.pezziCaricati >= 3)
        {
            bool1.GetComponent<TextMesh>().text = "OK";
            bool1.GetComponent<TextMesh>().color = Color.green;
        }  
    }

    public void CheckCentralina()
    {
        if (PezzoController.pezziCaricati >= 3)
        {
            if (!CentralinaChecked)
            {
                Debug.Log("Pannello: Centralina");
                bool2.GetComponent<TextMesh>().text = "OK";
                bool2.GetComponent<TextMesh>().color = Color.green;

                CentralinaChecked = true;
            }
        }
    }

    public void CheckAria()
    {
        Debug.Log("Aria cliccata");

        if (PezzoController.pezziCaricati >= 3)
        {
            if (CentralinaChecked)
            {
                Debug.Log("Check centralina");

                if (!AriaChecked)
                {
                    AriaChecked = true;
                    Debug.Log("Pannello: Aria");
                    bool3.GetComponent<TextMesh>().text = "OK";
                    bool3.GetComponent<TextMesh>().color = Color.green;
                }
            }
        }
    }
}
