using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MainScreen
{

    [SerializeField] private Button continueBtn;
    [SerializeField] private Button PlayScreenBtn;
    [SerializeField] private Button restartBtn;
    public static bool cllsecondTime = false;

   
    void Start()
    {
        continueBtn.onClick.AddListener(MainScreenNavigate);
        PlayScreenBtn.onClick.AddListener(PlayScreenNavigate);
        restartBtn.onClick.AddListener(Restartgame);

    }

    // Update is called once per frame
    void Update()
    {

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
                //Debug.Log("GamePLay");
                Ballspawner.instance.InputEnableDisable += Ballspawner.instance.OnmouseManage;
                break;
          
          
        }
    }

    void MainScreenNavigate()
    {
        ScreenManager.instance.ShowNextScreen(ScreenType.ScoreScreen);
        //Ballspawner.isPlay = false;
        //Time.timeScale = 1;
        //StartCoroutine(ballInputs());
        AudioManager.instance.Play("button");

    }
    void PlayScreenNavigate()
    {
        AudioManager.instance.Play("button");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Ballspawner.isPlay = false;
        //Time.timeScale = 1;
        //StartCoroutine(ballInputs());
    }

    void Restartgame()
    {
        AudioManager.instance.Play("button");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Ballspawner.isPlay = false;
        //Time.timeScale = 1;
        //StartCoroutine(ballInputs());
    }

    IEnumerator ballInputs()
    {
        yield return new WaitForSeconds(0.5f);
        Ballspawner.instance.isSpawnBall = false;
    }
}
