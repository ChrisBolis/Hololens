using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class click : MonoBehaviour, IInputClickHandler
{
    // Start is called before the first frame update
    GameObject testo;
    TextMesh textMesh;
    InputManager inputManager;
    TextMesh  testoDaCambiare;
    [SerializeField] string stringa = "testomodificato";

    void Start()
    {
        testo = GameObject.FindWithTag("Bool1");
        testoDaCambiare = testo.GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        UpdateText();
    }
    public void UpdateText()
    {
        
        testoDaCambiare.text= stringa;

        Debug.Log("Success");
    }
}
