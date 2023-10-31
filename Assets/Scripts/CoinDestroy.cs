using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    static int coin;


    private void OnEnable()
    {
        coin = int.Parse(SaveManager.instance.scoreTxt.text);
    }
    void Start()
    {
       
       SaveManager.instance.scoreTxt.text = coin.ToString();
    }

        // Update is called once per frame
        void Update()
    {
      //  SaveManager.instance.scoreTxt.text = coin.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            AudioManager.instance.Play("coin");
            Destroy(gameObject);

            coin += 1;
            SaveManager.instance.setCoin(coin.ToString());
        }
    }
}
