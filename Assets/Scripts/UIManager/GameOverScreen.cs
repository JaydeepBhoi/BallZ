using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField] private Button replay;
    [SerializeField] private Button PlayScreenBtn;
  

    // Start is called before the first frame update
    void Start()
    {
        replay.onClick.AddListener(MainScreenNavigate);
        PlayScreenBtn.onClick.AddListener(PlayScreenNavigate);
    

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MainScreenNavigate()
    {
        AudioManager.instance.Play("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Ballspawner.isPlay = false;
        Time.timeScale = 1;
        StartCoroutine(ballInputs());

    }
    void PlayScreenNavigate()
    {
        AudioManager.instance.Play("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Ballspawner.isPlay = false;
        Time.timeScale = 1;
        StartCoroutine(ballInputs());
    }

    IEnumerator ballInputs()
    {
        yield return new WaitForSeconds(0.5f);
        Ballspawner.instance.isSpawnBall = false;
    }


}
