using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************* SCRIPT PER IL CARICAMENTO DEL MACCHINARIO DALLA MATTONELLA *************************************/

public class OnLoadMacchinario : MonoBehaviour
{
    GameObject mattonella;

    // Quando lo script si avvia -> dopo il tap sulla mattonella...
    void Start()
    {
        // ...cerca la mattonella...
        mattonella = GameObject.FindWithTag("Mattonella");

        // ...e posiziona il macchinario
        gameObject.transform.position = mattonella.transform.position;    
        gameObject.transform.rotation = mattonella.transform.rotation;

        mattonella.SetActive(false);
    }
}
