using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    [HideInInspector]
    public Canvas canvas;
    
    public ScreenType screenType;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
}

public enum ScreenType
{
    MainScreen,
    ScoreScreen,
    PauseScreen,
    GameOverScreen,
    ShopScreen

}
