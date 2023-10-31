using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;

    //public PlayerData playerData;


    static string filePath;


    int score = 0;

    public int highScr=0,counterHighScore=0;

    string filePath2;

    public TextMeshProUGUI scoreTxt, levelTxt,highScoreTxt,gameOverBestScore,gameoverLevel;

    public  PlayerData playerData = new PlayerData();

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/jsonDataSave.json";
        //filePath2 = Application.persistentDataPath + "/jsonDataSave.don";
        LoadPlayer();
        instance = this;

        scoreTxt.text = playerData.coin;
        highScoreTxt.text = playerData.highScore;
        gameOverBestScore.text = playerData.highScore;
    }


    public void savePlayer()
    {
        //BinaryFormatter formetor = new BinaryFormatter();
        //// string filePath = Application.persistentDataPath + "/SaveDataManagerTask.jd";
        //FileStream fstream = new FileStream(filePath2, FileMode.Create);
        //formetor.Serialize(fstream, playerData);
        //fstream.Close();


        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, jsonData);

    }


    public void setCoin(string score)
    {

        playerData.coin = score;
        scoreTxt.text = playerData.coin;

//        Debug.Log("SCORE" + playerData.coin);
        savePlayer();
    }

    public void setLevel(string level)
    {
        levelTxt.text = level;
    }

    public void setHighScore(string level) {


        Debug.Log("HIGH" + level);

        int getScore = int.Parse(level);
        if (counterHighScore < getScore) {

            counterHighScore = getScore;

            playerData.highScore = counterHighScore.ToString();

            highScoreTxt.text = playerData.highScore;
        }

       
        savePlayer();

    }


    public void LoadPlayer()
    {


        if (File.Exists(filePath))
        {

            string jsonData = File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);

          
        }
        else
        {
            Debug.Log("No file are there");
        }


        //if (File.Exists(filePath2))
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    FileStream fileStream = new FileStream(filePath2, FileMode.Open);
        //    playerData = formatter.Deserialize(fileStream) as PlayerData;
        //    fileStream.Close();


        //}
        //else
        //{
        //    Debug.Log("********* File Not Exists ************");

        //}
    }
}

[System.Serializable]

public class PlayerData
{
    public string coin;
    public string highScore;
  
}



