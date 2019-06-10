using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int Health = 1000;
    public float xMax = 0, xMin = 0;
    //get a reference for gameobject player
    public GameObject player;
    GenerateMove geneMove;

    public void MovePlayer()
    {
        //take a reference to the player position
        Vector3 movement = transform.position;
        geneMove = GetComponent<GenerateMove>();
        if (Input.GetMouseButtonDown(0))
        {
            movement.x += geneMove.getDirection();
            transform.position = new Vector3(
                Mathf.Clamp(movement.x,xMin,xMax),
                transform.position.y,
                transform.position.z
                );
        }
    }

    //return the player position for random generation in 
    //generatemove script
    public Vector3 getPlayerPosition()
    {
        return transform.position;
    }

    public float getMaxMap()
    {
        return xMax;
    }

    public float getMinMap()
    {
        return xMin;
    }

    //player functionality: damage

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block" || other.tag == "block")
        {
            Health -= 10;
        }
        else if (other.tag == "Recover" || other.tag == "recover")
        {
            Health += 10;
        }
    }
    
    void FixedUpdate()
    {
        MovePlayer();
    }
}
