using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadSceneBySceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadNextScene()
    {
        // todo fix length problem for scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
