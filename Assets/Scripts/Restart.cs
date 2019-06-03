using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;

public class Restart : MonoBehaviour, IInputClickHandler
{
    [SerializeField] string sceneName;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())        
            Destroy(o);

        SceneManager.UnloadSceneAsync("MacchinarioScene");
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        SpatialMappingManager.Instance.StartObserver();
        SpatialMappingManager.Instance.DrawVisualMeshes = true;
    }
}
