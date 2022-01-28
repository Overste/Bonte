using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BontCastle : MonoBehaviour
{
    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private List<TextSO> texts = new List<TextSO>();
    private TextSO _currentText;
    private int _currentTextIndex;

    [Header("Buttons")] 
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    [Header("Images")] [SerializeField] private Image playerImage;


    private void Start()
    {
        DisplayText();
        GameManager.Instance.SetupPlayerImage(playerImage);
        GameManager.Instance.RotatePlayerImage(playerImage);
    }


    private void DisplayText()
    {
        // todo replace while function with better option
        while (texts.Count != 0)
        {
            _currentText = texts[_currentTextIndex];
            textMeshPro.text = _currentText.GetText();
            return;
        }
    }

    public void OnClickNextText()
    {
        if (_currentTextIndex < texts.Count - 1)
        {
            _currentTextIndex++;
            DisplayText();
        }
        else
        {
            SceneHandler.LoadNextScene();
        }
    }

    public void OnClickPreviousText()
    {
        if (_currentTextIndex > 0)
        {
            _currentTextIndex--;
            DisplayText();
        }
    }
}
