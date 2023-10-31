using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopItems : MonoBehaviour
{

    
    void Start()
    {
        if (int.Parse(gameObject.GetComponent<TextMeshProUGUI>().text.ToString()) >= int.Parse(SaveManager.instance.scoreTxt.ToString()))
        {
            Debug.Log("Hi...");
        }
        else
        {
            Debug.Log("Sorry");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
