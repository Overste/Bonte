using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    public static void ActivateCanvas(string canvasText)
    {
        GameObject.Find(canvasText).gameObject.SetActive(true);
    }
    
    public static void DeactivateCanvas(string canvasText)
    {
        GameObject.Find(canvasText).gameObject.SetActive(false);
    }
}
