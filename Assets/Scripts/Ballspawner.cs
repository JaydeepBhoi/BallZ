using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;


public class Ballspawner : MonoBehaviour
{
    private Vector3 worldPosition;
    private Vector3 startPos, endPos;

    public GameObject ballPrefab;
    //   public Transform spawnPointer;

    public static int countTmep = 0;

    public static Ballspawner instance;

    public TextMeshProUGUI ballText;

    [HideInInspector]

    public  bool isSpawnBall=false;

    Vector3 direction;
    Vector3 directionLinePoint;


    public GameObject BallObj;

   public  int counterBall,tempdestroyBall,balldestroy;

   public List<GameObject> ballPrefList=new List<GameObject>();

   
   private DirectionLine directionLine;

    BlockSpawner blockSpawner;


    public Action InputEnableDisable;
    static int count;

   public static bool isPlay=true;

    public bool isTouchmouse;
    public float ycheck;
    public bool isstarted=false;
    Vector3 callDir;
    private void Awake()
    {
        directionLine = GetComponent<DirectionLine>();
        blockSpawner = FindObjectOfType<BlockSpawner>();

    }

    private void OnEnable()
    {
         GameStateManager.OnGameStateChange += ChangeState;
    }

    private void ChangeState(GameState gs)
    {
        switch (gs)
        {
            case GameState.ScoreScreen:
            
                InputEnableDisable += OnmouseManage;
                break;
            case GameState.PauseScreen:
              
                InputEnableDisable -= OnmouseManage;
                break;
            case GameState.GameOver:
                InputEnableDisable -= OnmouseManage;
                break;
            default:
                InputEnableDisable += OnmouseManage;
                break;
        }
    }

    void Start()
    {
        

        instance = this;
        //    counterBall = ObjectPool.instance.amountToPool;
        //    counterBall = 1;

      
        counterBall = 1;
        ballText.text = "X" + counterBall;
        tempdestroyBall = 0;
        blockSpawner.spawnBlock();

        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("thew input mouse poasiution"+Input.GetMouseButton(0));
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * - 10f;
       InputEnableDisable?.Invoke();
        

    }

    public void OnmouseManage()
    {

        if (isPlay == false)
        {
            
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
              
                mouseDonw(worldPosition);
                isstarted = true;
                // isSpawnBall = false;
            }
            else if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() && isstarted)
            {
               
                mouseDrag(worldPosition);
                //  isSpawnBall = false;
            }
            else if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                mouseUp();

            }
        }
    }


    void mouseDonw(Vector3 worldPos)
    {
        if (isSpawnBall == false )
        {
           

            FindObjectOfType<DirectionLine>().lineRenderer.SetPosition(0, Vector3.zero);
            FindObjectOfType<DirectionLine>().lineRenderer.SetPosition(1, Vector3.zero);
            startPos = worldPos;

            
            directionLine.lineRenderer.enabled = false;
            directionLine.startPoints(transform.position);
            //isstarted = true;



        }
    }

    private void mouseDrag(Vector3 worldPos)
    {
        if (isSpawnBall == false )
        {
            Debug.Log("here in drag");
            endPos = worldPos;

             callDir = endPos - startPos;
            directionLinePoint = endPos - startPos;
            directionLine.endPoints(transform.position - directionLinePoint);
           


            //    Debug.Log("DDDD=="+ callDir.magnitude);

            if (callDir.magnitude >= 0.95f)
            {
               
               

                float angle = Mathf.Atan2(callDir.y, callDir.x) * Mathf.Rad2Deg - 90f;

                transform.eulerAngles = Vector3.forward * angle;

                Debug.Log("Angle" + angle);

                if(angle >=-95 ||  angle<=-265)
                {
                    directionLine.lineRenderer.enabled = false;
                    isTouchmouse = false;

                }
                else
                {
                    isTouchmouse = true;
                    directionLine.lineRenderer.enabled = true;
                }
            }
            else
            {
                return;
            }
            

          
            
        }
    }

  
    private void mouseUp()
    {
        if (isSpawnBall == false && isTouchmouse )
        {
          
            isSpawnBall = true;
            direction = endPos - startPos;
            ycheck = direction.y;
           direction.Normalize();
            directionLine.lineRenderer.enabled = false;

         

            
            StartCoroutine(spawnBallPrefab());
            //isstarted = false;
          // 
        }
    }


    IEnumerator spawnBallPrefab()
    {

      
        count = counterBall;
    
          for (int i = 1; i <= counterBall; i++)
            {
                tempdestroyBall = i;

                BallObj = ObjectPool.instance.pooObject();



                if (BallObj != null)
                {
                    BallObj.transform.position = transform.position;
                    BallObj.transform.rotation = transform.rotation;

                    BallObj.SetActive(true);
                    //BallObj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
                    BallObj.GetComponent<Rigidbody2D>().AddForce(-direction);

                    //Debug.Log("FORCE" + -direction);

                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    ballText.enabled = false;
                }


                if (count >= 0)
                {
                    count = count - 1;
                    ballText.text = "X" + count;
                    Debug.Log(count);
                }

                //

                ballPrefList.Add(BallObj);




                yield return new WaitForSeconds(0.1f);

                countTmep = 1;


            }
        }

    
}
