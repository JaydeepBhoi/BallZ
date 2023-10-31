using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{


   
    public List<GameObject> ListPolledObjects;

    public GameObject poolPrefab;

    public int amountToPool;

    public static ObjectPool instance;
    GameObject tmpObj;
    void Start()
    {

        instance = this;
        ListPolledObjects = new List<GameObject>();
       

        for(int i = 0; i < amountToPool; i++)
        {
            tmpObj = Instantiate(poolPrefab);
            tmpObj.SetActive(false);

            ListPolledObjects.Add(tmpObj);

        }
    }


    public GameObject pooObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {

            if (!ListPolledObjects[i].activeInHierarchy)
            {
                return ListPolledObjects[i];
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
