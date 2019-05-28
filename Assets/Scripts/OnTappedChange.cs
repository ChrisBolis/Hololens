using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace HololensProject {
    public class OnTappedChange : MonoBehaviour, IInputClickHandler
    {
        [SerializeField] string SceneName;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        }
    }
}
