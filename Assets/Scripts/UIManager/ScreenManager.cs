using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public BaseClass[] screens;
    public BaseClass currentScreen;
    public static ScreenManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentScreen.canvas.enabled = true;
        GameStateManager.instance.currentState = GameState.MainScreen;
    }

    public void ShowNextScreen(ScreenType screenType)
    {
        currentScreen.canvas.enabled = false;

        foreach (BaseClass baseScreen in screens)
        {
            if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = true;
                currentScreen = baseScreen;
                break;
            }

        }

        switch (screenType)
        {
            case ScreenType.MainScreen:
                GameStateManager.instance.ChangeState(GameState.MainScreen);
                break;
            case ScreenType.ScoreScreen:
                GameStateManager.instance.ChangeState(GameState.ScoreScreen);
                break;
            case ScreenType.PauseScreen:
                GameStateManager.instance.ChangeState(GameState.PauseScreen);
                break;
            case ScreenType.GameOverScreen:
                GameStateManager.instance.ChangeState(GameState.GameOver);
                break;
            case ScreenType.ShopScreen:
                GameStateManager.instance.ChangeState(GameState.GameOver);
                break;




        }
    }

  
}
