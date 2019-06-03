using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;
using UnityEngine.SceneManagement;

/************************************* SCRIPT PER INIZIALIZZARE IL CARICAMENTO DELLA SCENA PRINCIPALE *************************************/

public class OnTappedChange : MonoBehaviour, IInputClickHandler
{
    [SerializeField] string sceneName;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        SpatialMappingManager.Instance.StopObserver();
        SpatialMappingManager.Instance.DrawVisualMeshes = false;
    }
}