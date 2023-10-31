using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManager :MonoBehaviour
{

    public static GameStateManager instance;

    public static Action<GameState> OnGameStateChange;

    public GameState currentState;

    
    private void Start()
    {
        instance = this;
    }

    public void ChangeState(GameState gs)
    {
        currentState = gs;
        OnGameStateChange?.Invoke(gs);
    }

}

public enum GameState
{
    MainScreen,
    ScoreScreen,
    PauseScreen,
    GameOver,
    ShoapScreen
}
