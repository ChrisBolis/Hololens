using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Calibrazione : MonoBehaviour, IInputClickHandler
{
    [SerializeField] GameObject mattonella;
    [SerializeField] Collider mattonellaCollider;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        mattonella.SetActive(true);
        mattonellaCollider.enabled = true;
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        mattonella.SetActive(false);
        mattonellaCollider.enabled = false;
    }
}
