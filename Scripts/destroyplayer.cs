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
    private GameManager managerscript;
    public int damage = -10;

    void Start()
    {
        GameObject GameManger = GameObject.FindGameObjectWithTag("GameController");
        if(GameManger!= null)
        {
            managerscript = GameManger.GetComponent<GameManager>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //add code to decrease health
            managerscript.ChangeHealth(damage);
        }
        else if (other.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
