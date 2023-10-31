using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnim : MonoBehaviour
{
    public float value;
    private float timer;
    public float timePeriod,freq;
    void Start()
    {
        freq = 1 / timePeriod;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        value = Mathf.Sin(2 * Mathf.PI * freq * timer);

        transform.position = new Vector3(transform.position.x, transform.position.y + (value *0.005f), transform.position.z);
        
    }
}
