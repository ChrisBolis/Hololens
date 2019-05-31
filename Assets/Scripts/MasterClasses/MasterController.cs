using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************* CLASSE MASTER CONTENETE TUTTI I PARAMETRI PUBBLICI CONDIVISI DA PIU' GAMEOBJECT *************************************/

public class MasterController : MonoBehaviour
{
    // Interfaccia...
    // ...Pannelli completi
    public GameObject errorUI, piecesUI, switchUI, startUI;

    // ...testi specifici
    public GameObject airStatus, powerStatus;
    public string airErrorMsg = "Pressione aria troppo bassa", powerErrorMsg = "Malfunzionamento interno";

    // Gestione pezzi meccanici
    public GameObject loader, spawner;

    // Grafica
    public GameObject alarmLight;

    // Materiali
    [SerializeField] Material alarmOFFMaterial, alarmONMaterial;

    // Campi statici
    [HideInInspector] public static int loadedPieces = 0;

    //********** METODI PUBBLICA **********

    public void switchLight(bool isOn)
    {
        alarmLight.GetComponent<Renderer>().material = isOn ? alarmONMaterial : alarmOFFMaterial;
    }
}