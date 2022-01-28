using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BontForestChallenge : MonoBehaviour
{
 [Header("Text")]
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private List<TextSO> texts = new List<TextSO>();
    [SerializeField] private TextSO positiveText;
    [SerializeField] private TextSO negativeText;
    private TextSO _currentText;
    private int _correctTextIndex;

    [Header("Buttons")]    
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button positiveButton;
    [SerializeField] private Button negativeButton;
    private List<Button> buttons = new List<Button>();


    [Header("Image")] 
    [SerializeField] private List<Sprite> backgroundImages = new List<Sprite>();
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image monsterImage;
    [SerializeField] private Image playerImage;
    private Color defaultColor = new Color(1f, 1f, 1f, 1f);
    private Color negativeColor = new Color(0.3f, 0.3f, 0.3f, 1f);

    // private GameObject bonteBosChallengeTwoCanvas;
    // private GameObject bonteBosChallengeThreeCanvas;
    private int _currentBackgroundImageIndex = 1;
    int oneMoreClick = 0;

    void Start()
    {
        monsterImage.color = negativeColor;
        monsterImage.transform.Rotate(new Vector3(0, 180, 0));

        playerImage.sprite = GameManager.Instance.PlayerSprite;
        playerImage.color = GameManager.Instance.PlayerColor;

        backgroundImage.sprite = backgroundImages[GameManager.Instance.backgroundSpriteIndex];
        GameObject[] btn = GameObject.FindGameObjectsWithTag("BaseButton");

        // Iterate through the array of 'btn' and add them to the 'buttons' list
        for (int i = 0; i < btn.Length; i++)
        {
            buttons.Add(btn[i].GetComponent<Button>());
            // buttons[i].gameObject.SetActive(false);

            // string text = buttons[i].GetComponentInChildren<TextMeshProUGUI>().name;
            string text = buttons[i].GetComponentInChildren<Button>().name;

            buttons[i].onClick.AddListener(() => SetEmotionalState(text));
        }
        
        monsterImage.color = negativeColor;
        DisplayText();
        MakeButtonsActive(); 
    }
    
    void DisplayText()
    {
        _currentText = texts[_correctTextIndex];
        textMeshPro.text = _currentText.GetText();
    }

    public void OnClickNextText()
    {
        if (_correctTextIndex < texts.Count - 1)
        {
            _correctTextIndex++;
            DisplayText();
        }
        
        if (_correctTextIndex == texts.Count - 1)
        {
            MakeButtonsActive();
        }
    }

    public void OnClickPreviousText()
    {
        if (_correctTextIndex > 0)
        {
            _correctTextIndex--;
            DisplayText();
        }
    }

    public void SetEmotionalState(string text)
    {
        if (text.ToUpper() == "LIEFDEVOL")
        {
            monsterImage.color = defaultColor;
            backgroundImage.sprite = backgroundImages[2];
            playerImage.color = defaultColor;
            textMeshPro.text = positiveText.GetText();
            GameManager.Instance.backgroundSpriteIndex++;
        }
        else
        {
            monsterImage.color = negativeColor;
            backgroundImage.sprite = backgroundImages[0];
            playerImage.color = negativeColor;
            textMeshPro.text = negativeText.GetText();
        }
    }
    
    // Example function making all of the buttons, non-interactable
    private void MakeButtonsActive()
    {
        // Iterate through each button in the 'buttons' list & set interactable to false
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
}
