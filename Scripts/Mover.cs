using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    void Start()/*start allow the object shows up in the very first frame*/
    {
        /*Rigidbody is a data type in unity engine and it has to be initialize to a value
         before using the function*/
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, speed, 0);
    }
}
