using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallDownCall : MonoBehaviour
{
    Ball ballRef;

    public Button callBalls;
    
    void Start()
    {
        ballRef = GetComponent<Ball>();

        callBalls.onClick.AddListener(downBall);

    }



    public void downBall() {


        ballRef.GetComponent<GameObject>().GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    }

}
