using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Calibrazione : MonoBehaviour, IInputClickHandler
{
    [SerializeField] GameObject mattonella;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        mattonella.SetActive(true);
        Destroy(gameObject);
    }
}
