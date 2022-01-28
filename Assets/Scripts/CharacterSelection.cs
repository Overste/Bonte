using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button startButton;

    [Header("Images")] 
    [SerializeField] private List<Sprite> characters = new List<Sprite>();
    [SerializeField] private Image character;

    private int characterIndex = 0;
    
    void Start()
    {
        character.sprite = characters[characterIndex];
    }

    public void OnClickNextCharacter()
    {
        if (characters.Count - 1 < ++characterIndex)
        {
            characterIndex = 0;
        }

        character.sprite = characters[characterIndex];
    }

    public void OnClickPreviousCharacter()
    {
        if (0 > --characterIndex)
        {
            characterIndex = 2;
        }

        character.sprite = characters[characterIndex];
    }

    public void StartGame()
    {
        Debug.Log(character.sprite);
        GameManager.Instance.PlayerSprite = character.sprite;
        SceneHandler.LoadNextScene();
    }
}
