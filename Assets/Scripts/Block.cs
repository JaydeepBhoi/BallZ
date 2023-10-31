using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Block : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public TextMesh Brikstext;

    int colorChange;

    int hitsBrikcs=5;

    bool isColor = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
       
        updateViewState();
    }

    public void updateViewState()
    {

        Brikstext.text= hitsBrikcs.ToString();
       
        //if (isColor == false)
        //{
        //    isColor = true;
        //    colorChange = Random.Range(1, 6);
        //   //  RandomColorBricks();
       
            
        //}
       
    }

    internal void setHits(int hitsBlock)
    {
        hitsBrikcs = hitsBlock;
        updateViewState();
    }

    private void RandomColorBricks() {

        switch (colorChange)
        {
            case 1:
                spriteRenderer.color = Color.Lerp(Color.white, Color.red, hitsBrikcs / 10f);
                break;
            case 2:
                spriteRenderer.color = Color.Lerp(Color.white, Color.green, hitsBrikcs / 10f);
                break;
            case 3:
                spriteRenderer.color = Color.Lerp(Color.white, Color.yellow, hitsBrikcs / 10f);
                break;
            case 4:
                spriteRenderer.color = Color.Lerp(Color.white, Color.blue, hitsBrikcs / 10f);
                break;
            case 5:
                spriteRenderer.color = Color.Lerp(Color.white, Color.cyan, hitsBrikcs / 10f);
                break;
            case 6:
                spriteRenderer.color = Color.Lerp(Color.white, Color.magenta, hitsBrikcs / 10f);
                break;
            default:
                spriteRenderer.color = Color.Lerp(Color.white, Color.grey, hitsBrikcs / 10f);
                break;

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  if (collision.gameObject.tag == "ball")
        {

            hitsBrikcs--;
            AudioManager.instance.Play("ballTouch");
            if (hitsBrikcs > 0)
            { 
                updateViewState();
               
            }
            else
            {
                Destroy(gameObject);

            }
        }
    }

}

