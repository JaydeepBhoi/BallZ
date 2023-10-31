using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopGenerator : MonoBehaviour
{
    public BallShop_SO ballShop;

    public GameObject buttonPrefab, parrentObj;

    public 

    Button Callbtn;
    public Button prefabBtn;
    GameObject buttonObj;
    void Start()
    {
        callData();
    }


    public void callData()
    {
        for(int i=0;i< ballShop.shopsData.Count; i++)
        {
            Callbtn = Instantiate(prefabBtn);
            Callbtn.transform.parent = parrentObj.transform;
            Callbtn.transform.localScale = new Vector3(1, 1, 1);
            Callbtn.image.sprite = ballShop.shopsData[i].buttonBallIcon;
            Callbtn.GetComponentInChildren<TextMeshProUGUI>().text = ballShop.shopsData[i].txt;

            Debug.Log("CalllScriptable Obj");
        }
    }
}
