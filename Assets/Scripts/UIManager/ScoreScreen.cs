using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{

    [SerializeField] private Button HomeButton;


    // Start is called before the first frame update
    void Start()
    {
        HomeButton.onClick.AddListener(HomeBtn);

    }

    private void OnEnable()
    {
        GameStateManager.OnGameStateChange += ChangeState;
    }

    private void ChangeState(GameState gs)
    {
        switch (gs)
        {
            case GameState.ScoreScreen:
               
                Ballspawner.instance.InputEnableDisable += Ballspawner.instance.OnmouseManage;
                break;


        }
    }


    void HomeBtn()
    {
        AudioManager.instance.Play("button");
        //Ballspawner.isPlay = true;
        ScreenManager.instance.ShowNextScreen(ScreenType.PauseScreen);
        //Time.timeScale = 0;
        //Ballspawner.instance.isSpawnBall = true;
    }


}
