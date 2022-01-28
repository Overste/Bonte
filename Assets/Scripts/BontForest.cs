using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BontForest : MonoBehaviour
{
    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private List<TextSO> texts = new List<TextSO>();
    [SerializeField] private TextSO positiveText;
    [SerializeField] private TextSO negativeText;
    private TextSO _currentText;
    private int _currentTextIndex = 0;

    [Header("Buttons")] 
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button positiveButton;
    [SerializeField] private Button negativeButton;

    [Header("Image")] 
    [SerializeField] private List<Sprite> backgroundImages = new List<Sprite>();
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image monsterImage;
    [SerializeField] private Image playerImage;
    private Color defaultColor = new Color(1f, 1f, 1f, 1f);
    private Color negativeColor = new Color(0.3f, 0.3f, 0.3f, 1f);

    private int _currentBackgroundImageIndex = 0;
    private int oneMoreClick = 0;
    
    private GameObject bonteBosChallengeTwoCanvas;

    
    private void Start()
    {
        DisplayText();
        GameManager.Instance.SetupPlayerImage(playerImage);
        
        // Image
        backgroundImage.sprite = backgroundImages[_currentBackgroundImageIndex];
        
        // Canvas
        bonteBosChallengeTwoCanvas = GameObject.Find("BontForestChallengeTwoCanvas");
        bonteBosChallengeTwoCanvas.SetActive(false);
        
        // Button
        positiveButton.gameObject.SetActive(false);
        negativeButton.gameObject.SetActive(false);
        
        // Monster
        monsterImage.transform.Rotate(new Vector3(0, 180, 0));
        monsterImage.color = negativeColor;
    }

    private void DisplayText()
    {
        _currentText = texts[_currentTextIndex];
        textMeshProUGUI.text = _currentText.GetText();
    }

    public void OnClickNextText()
    {
        if (_currentTextIndex < texts.Count - 1)
        {
            Debug.Log("1");
            _currentTextIndex++;
            DisplayText();
        }

        if (_currentTextIndex == texts.Count -1)
        {
            positiveButton.gameObject.SetActive(true);
            negativeButton.gameObject.SetActive(true);
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

    public void OnClickPositive()
    {
        monsterImage.color = defaultColor;
        backgroundImage.sprite = backgroundImages[++_currentBackgroundImageIndex];
        GameManager.Instance.BackgroundSprite = backgroundImage.sprite;
        GameManager.Instance.PlayerColor = defaultColor;

        
        
        textMeshProUGUI.text = positiveText.GetText();
        negativeButton.interactable = false;
        
        if (oneMoreClick == 1)
        {
            CanvasHandler.DeactivateCanvas("BontForestChallengeOneCanvas");
            GameManager.Instance.backgroundSpriteIndex = 1;
            bonteBosChallengeTwoCanvas.SetActive(true);
        }

        oneMoreClick++;
    }

    public void OnClickNegative()
    {
        Debug.Log("clicked");
        playerImage.color = negativeColor;
        GameManager.Instance.PlayerColor = negativeColor;

        // todo backgrond swab
        textMeshProUGUI.text = negativeText.GetText();
        positiveButton.interactable = false;

        if (oneMoreClick == 1)
        {
            GameManager.Instance.backgroundSpriteIndex = 0;
            GameManager.Instance.backgroundSpriteIndex = 0;
            bonteBosChallengeTwoCanvas.SetActive(true);
        }

        oneMoreClick++;
    }
}
