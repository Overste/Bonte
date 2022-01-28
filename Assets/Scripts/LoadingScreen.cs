using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    async void Start()
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        SceneHandler.LoadNextScene();
    }
}
