using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoadMacchinario : MonoBehaviour
{
    [SerializeField] GameObject Macchinario;

    GameObject Mattonella;
    void Start()
    {
        Mattonella = GameObject.FindWithTag("Mattonella");

        Macchinario.transform.position = Mattonella.transform.position;    
        Macchinario.transform.rotation = Mattonella.transform.rotation;

        Mattonella.SetActive(false);
    }
}
