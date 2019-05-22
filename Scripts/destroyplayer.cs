using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
purpose: this will make player lose health instead of destroying the player instantly
the Block will also be destroied once it hits the boundary
parameter: other and the tag to identify which object to interact with
return: none
*/

public class destroyplayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //add code to decrease health
        }
        else if (other.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
