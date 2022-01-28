using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour
{
    [Header("Buttons")] 
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button startButton;

    [FormerlySerializedAs("characters")]
    [Header("Images")] 
    [SerializeField] private List<Sprite> backgrounds = new List<Sprite>();
    [FormerlySerializedAs("character")] [SerializeField] private Image background;

    private int backgroundIndex = 0;
    
    void Start()
    {
        background.sprite = backgrounds[backgroundIndex];
    }

    public void OnClickNextWorld()
    {
        if (backgrounds.Count - 1 < ++backgroundIndex)
        {
            backgroundIndex = 0;
        }

        background.sprite = backgrounds[backgroundIndex];
    }

    public void OnClickPreviousWorld()
    {
        if (0 > --backgroundIndex)
        {
            backgroundIndex = 2;
        }

        background.sprite = backgrounds[backgroundIndex];
    }

    public void LoadWord()
    {
        GameManager.Instance.PlayerSprite = background.sprite;
        SceneHandler.LoadNextScene();
    }
}
