using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************* CLASSE MASTER CONTENETE TUTTI I PARAMETRI PUBBLICI CONDIVISI DA PIU' GAMEOBJECT *************************************/

public class MasterController : MonoBehaviour
{
    // Interfaccia
    public GameObject errorUI, piecesUI, switchUI, startUI;

    // Gestione pezzi meccanici
    public GameObject loader, spawner;

    // Campi statici
    [HideInInspector] public static int loadedPieces = 0;

    // Suoni & audio



}