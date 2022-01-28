using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite PlayerSprite { get; set; }
    public Color PlayerColor { get; set; }
    
    public string PlayerSpritePath { get; set; }
    public int PlayerLife { get; set; }

    public Sprite BackgroundSprite { get; set; }
    public int backgroundSpriteIndex { get; set; }
    
    public static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public void SetupPlayerImage(Image playerImage)
    {
        while (playerImage != null)
        {
            playerImage.sprite = PlayerSprite;
            return;
        }
    }

    public void RotatePlayerImage(Image playerImage)
    {
        while (playerImage != null)
        {
            playerImage.transform.Rotate(new Vector3(0, 180, 0));
            return;
        }
    }
}
