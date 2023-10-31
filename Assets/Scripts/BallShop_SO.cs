
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Card" , menuName ="ShopInventory")]
public class BallShop_SO : ScriptableObject
{
    public List<ShopData> shopsData=new();
}

[System.Serializable]
public class ShopData {


    public string txt;
    public Sprite buttonBallIcon;
    public Sprite lockImage;
  
}
