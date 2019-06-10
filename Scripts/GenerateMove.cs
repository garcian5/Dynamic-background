using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateMove : MonoBehaviour
{
    public GameObject[] arrows;
    public int number = 4;//this is for how many directions will be shown on screen
    List<float> direction = new List<float>();
    //set the preset distance for player to move
    public float distance = 1;
    PlayerControl playerScript;

    //create a list that contains 4 directions
    public void CreateDirection()
    {
        for (int i = 0; i < number; i++)
        {
            direction.Add(DrawDirection());
        }
    }

    //helper function to draw
    public float DrawDirection()
    {
        int draw = Random.Range(0,99);
        if (draw <= 49)
        {
            return -(distance);
        }
        else{
            return distance;
        }
    }

    //if this is called by the player than it means the player moves
    public float getDirection()
    {
        float oldDirection = direction[0];
        ShiftLeft(direction);
        return oldDirection;
    }

    //shift the elements in a list to left
    void ShiftLeft(List<float> list)
    {
        playerScript = GetComponent<PlayerControl>();
        Vector3 position = playerScript.getPlayerPosition();
        Debug.Log("The length of list is "+list.Count);
        for (int i = 0; i < (list.Count-1); i++)
        {
            list[i] = list[i + 1];
            
        }
        //make sure the player will be in the boundary
        list[list.Count - 1] = DrawDirection();
        if (Checkposition(list))
        {
            if (position.x >= playerScript.getMaxMap() && list[list.Count - 1] > 0)
            {
                list[list.Count - 1] = list[list.Count - 1] * -1;
            }
            else if (position.x <= playerScript.getMinMap() && list[list.Count - 1] < 0)
            {
                list[list.Count - 1] = list[list.Count - 1] * -1;
            }
        }       
    }

    bool Checkposition(List<float> list)
    {
        playerScript = GetComponent<PlayerControl>();
        Vector3 position = playerScript.getPlayerPosition();
        float Sum = 0;
        for (int i = 0; i < (list.Count-1); i++)
        {
            Sum += list[i];
        }
        if(position.x+Sum >= playerScript.getMaxMap() && position.x + Sum >= playerScript.getMinMap())
        {
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("create direction");
        CreateDirection();
    }
}
