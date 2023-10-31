using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private GameObject ballspawner;

    [SerializeField]
    private GameObject scoreSpawnwer;
    public GameObject parentObject;

    private int  blockSize=7;
    int hitsBlock;

    private float distanceBetweenBlocks=0.78f;

    private int rowSpan=1, scoreCheck,ballsCheck;

    GameObject block, ScoreObj;
    int counterPower=0;
    int maintainScore;

    int ScoreCall, BallsCall;

    public List<GameObject> blockSpawn = new List<GameObject>();
   
    GameObject ballSpawn;

   private int level;


    public static BlockSpawner instance;

    public Action spawnBlocksAction;

    Ballspawner ballspawnerCall;

    public Action callRestartBlocks;
    public Vector2 worldPos;
    private void OnEnable()
    {
        instance = this;
        spawnBlocksAction += spawnBlock;
//        level = int.Parse(SaveManager.instance.scoreTxt.text);

        callRestartBlocks += restartGameBlock;

        if (MainScreen.ispawnObj == true)
        {
            for (int i = 1; i < 1; i++)
            {
                spawnBlocksAction?.Invoke();
                //spawnBlock();
            }
        }
    
    }

    
    

  
   


    private void Start()
    {
       
        ballspawnerCall = GetComponent<Ballspawner>();
    }


    public void restartGameBlock()
    {
        blockSpawn.Clear();
        rowSpan = 1;
        SaveManager.instance.levelTxt.text = (rowSpan - 1).ToString();
     //   ballspawnerCall.counterBall = 1;
    }

    public void spawnBlock()
    {

        foreach(var block in blockSpawn)
        {
            if(block != null)
            {
                block.transform.position += Vector3.down * distanceBetweenBlocks;

              //  block.transform.position = Vector3.Lerp(transform.position, Vector3.down * distanceBetweenBlocks, Time.deltaTime);

                ballsCheck = 0;
                scoreCheck = 0;
               
            }
           

        }

        for (int i = 1; i <= blockSize; i++)
        {
            if (UnityEngine.Random.Range(0, 100) <= 40)
            {
                

                block = Instantiate(blockPrefab, GetPosition(i), Quaternion.identity);
                block.transform.parent = parentObject.transform;


                hitsBlock = UnityEngine.Random.Range(1, 3) * rowSpan;
                block.GetComponent<Block>().setHits(hitsBlock);
                blockSpawn.Add(block);
                maintainScore = i;
                RandomColorBricks();
               
            }
            else
            {
                

                    if (Random.Range(0, 100) <= 30 && rowSpan != 1 && ballsCheck == 0)
                    {
                        
                        ballSpawn = Instantiate(ballspawner, GetPosition(i), Quaternion.identity);
                        ballSpawn.transform.parent = parentObject.transform;
                        blockSpawn.Add(ballSpawn);
                        ballsCheck = 1;
                    }
                    else
                    {
                       if (Random.Range(0, 100) <= 10 && rowSpan != 1 && scoreCheck==0)
                        {
                            ScoreObj = Instantiate(scoreSpawnwer, GetPosition(i), Quaternion.identity);
                            ScoreObj.transform.parent = parentObject.transform;
                            blockSpawn.Add(ScoreObj);
                            scoreCheck = 1;
                        }
                    }
                

            }

        }

      //  RandomColorBricks();

        rowSpan++;

        SaveManager.instance.levelTxt.text = (rowSpan - 1).ToString();
        SaveManager.instance.gameoverLevel.text = (rowSpan - 1).ToString();
        SaveManager.instance.gameoverLevel.text = "BEST "+(rowSpan - 1);
        
        SaveManager.instance.highScr=int.Parse(SaveManager.instance.levelTxt.text);



    }

    private Vector2 GetPosition(int i)
    {
        Vector2 position = transform.position;
         worldPos = Camera.main.WorldToViewportPoint(position);
        position += Vector2.right * i * distanceBetweenBlocks;
        return position;
    }

   

    private void RandomColorBricks()
    {
       int    colorChange = Random.Range(1, 6);
        switch (colorChange)
        {
            case 1:
                block.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                block.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 3:
                block.GetComponent<SpriteRenderer>().color = Color.gray;
                break;
            case 4:
                block.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 5:
                block.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 6:
                block.GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            default:
                block.GetComponent<SpriteRenderer>().color = Color.red;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
