using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{

    [SerializeField] private Button ShopBtn;
    void Start()
    {
        ShopBtn.onClick.AddListener(HomeBtn);
    }

    public void HomeBtn()
    {
        ScreenManager.instance.ShowNextScreen(ScreenType.MainScreen);
    }
}
