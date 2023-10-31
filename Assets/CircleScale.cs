using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScale : MonoBehaviour
{
    // Start is called before the first frame update

    //public Vector3 minScale;
    //public Vector3 maxScale;

    //private bool repeatFlag=true;

    //public float scalingSpeed;
    //public float scalingDuration;

    Animation anim;


    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.Play();
    }


    //private IEnumerator Start()
    //{

    //    while(repeatFlag)
    //    {

    //        yield return scalingObject(minScale, maxScale,scalingDuration);
    //        yield return scalingObject(maxScale, minScale, scalingDuration);

    //    }

    //}


    //IEnumerator scalingObject(Vector3 startScaling,Vector3 endScaling,float time)
    //{
    //    float t = 0.0f;
    //    float rate = (1f / time) * scalingSpeed;

    //    if (t < 1f)
    //    {
    //        t += Time.deltaTime * rate;
    //        transform.localScale = Vector3.Lerp(startScaling, endScaling, t);
    //        yield return null;
    //    }
    //}
}
