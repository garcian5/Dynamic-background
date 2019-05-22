using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 purpose: destroy any unexpected gameObject by a given time
 parameter:the number of the time
 return: none
     */
public class DestroyByTime : MonoBehaviour
{
    public float LifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }
}
