using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   
   public  float speed=8f;

    static int counterAddBall = 0;

    public static bool isDestroyAllObj = false;
    
    private Rigidbody2D rgBody;

    static int counterDestroy;


    DirectionLine directionLine;

    BlockSpawner blockSpawner;

    float speedStore;

    public Action OnMoveBalls;

    public Vector2 storeVelocity;

    private void OnEnable()
    {
        speedStore = speed;
        blockSpawner = FindObjectOfType<BlockSpawner>();
      
        rgBody = GetComponent<Rigidbody2D>();
        GameStateManager.OnGameStateChange += ChangeState;
    }

    void Start()
    {
       
        directionLine = GetComponent<DirectionLine>();

      

        Debug.Log(speedStore);

    }





private void ChangeState(GameState gs)
{
    switch (gs)
    {
        case GameState.ScoreScreen:

                speed = speedStore;
              //  gameObject.GetComponent<Rigidbody2D>().velocity = storeVelocity.normalized;
                break;
        case GameState.PauseScreen:

                storeVelocity = rgBody.velocity;
                speed = 0;
               break;
      
    }
}



    private void FixedUpdate()
    {
        moveBall();
        
    }


    public void moveBall()
    {
        rgBody.velocity = rgBody.velocity.normalized * speed;

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomLine" && Ballspawner.countTmep==1)
        {
        
            counterDestroy++;

            Ballspawner.instance.ballText.text = "X" + counterDestroy;
            if (counterDestroy== Ballspawner.instance.ballPrefList.Count)
            {

             
                Ballspawner.countTmep = 0;
                Ballspawner.instance.ballPrefList.Clear();
               
       

                Ballspawner.instance.transform.position = new Vector2(gameObject.transform.position.x, -4.74f);
                Ballspawner.instance.ballText.transform.position= new Vector2(gameObject.transform.position.x, Ballspawner.instance.ballText.transform.position.y+0.001f);

                Ballspawner.instance.ballText.text = "X" + Ballspawner.instance.counterBall;
            
              
                counterAddBall = 0;
                counterDestroy = 0;
                blockSpawner.spawnBlock();

                Ballspawner.instance.isSpawnBall = false;
                Ballspawner.instance.isTouchmouse = false;

                Ballspawner.instance.isstarted = false;

                Ballspawner.instance.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                Ballspawner.instance.ballText.enabled = true;
            }



            gameObject.SetActive(false);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "ballPower")
        {
            AudioManager.instance.Play("button");
            counterAddBall++;
            Ballspawner.instance.counterBall++; 
            Destroy(collision.gameObject);

        }
    }


}
