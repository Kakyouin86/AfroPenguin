using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangebtwScenes : MonoBehaviour
{

    public string sceneName;
    public Button loadSceneBtn;

    void Start()

    {
        loadSceneBtn.onClick.AddListener(ChangeScene);

    }

    void ChangeScene()

    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
