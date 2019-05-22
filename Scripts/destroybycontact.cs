using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 purpose:destroy gameObject once it touches the boundary or the player it will destroy the gameObject
 parameter:a gameObject
 return:none
 */
public class destroybycontact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);//destroy game object will destroy to the object the script is attached to.
            //**destroy does not immediately destroy but it is destroy at the end of the frame
        }
        else if (other.tag == "Player")
        {
            Destroy(gameObject);
            //add code to increase health point and score
        }
    }
}
