using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinManage : MonoBehaviour
{

    //public static int Coin;
    public   int coinVal;
    public  TextMeshProUGUI scoreTxt,levelTxt;

    public static CoinManage instance;
    void Start()
    {
       instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public  void setScore(string score)
    {
        scoreTxt.text = score;
    }

    public void setLevel(string level)
    {
        levelTxt.text = level;
    }
    


}
