using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAfterTime : MonoBehaviour
{
    public float delayBeforeLoading = 2.5f;
    public string sceneNameToLoad;
    public float timeElapsed = 0.0f;


    public void Update()
    {
        Time.timeScale = 1.0f;
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
