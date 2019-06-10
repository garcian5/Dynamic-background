using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject Block;
    public GameObject Recover;
    public Vector3 OriginPosition;
    public int WaveCount;
    public float StartWait;
    public float WaveWait;
    public int damagerPerWave = -1;
    private GameManager managerscript;
    private int i = 0, j = 0, blocknum=0;
    List<int> ListSpawn = new List<int>();

    /*
purpose: this script controls the way the Block and the recovery spawn,
the spawn time, and the spawn position
parameter: two gameObjects, the wait until begin time, spawn time for next wave, spawn time for each
game object, the position for spawning, and the number that will spawn

*/
    private void Start()
    {
        StartCoroutine(SpawnObject());
        GameObject GameManger = GameObject.FindGameObjectWithTag("GameController");
        if (GameManger != null)
        {
            managerscript = GameManger.GetComponent<GameManager>();
        }
        Debug.Log("after find game object");
    }

    

    // Start is called before the first frame update
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(StartWait);
        while (true) {
            CreateList();
            Debug.Log("CheckPoint1");
            for (int i = 0; i < 7; i++) {
                //the for loop controls how many object will be spawn at once
                Vector3 BlockPosition = new Vector3((OriginPosition.x-6)+i, OriginPosition.y, OriginPosition.z);
                Quaternion BlockRotation = Quaternion.identity;
                switch (ListSpawn[i])
                {
                    case 0:
                        Instantiate(Block, BlockPosition, BlockRotation);
                        break;
                    case 1:
                        Instantiate(Recover, BlockPosition, BlockRotation);
                        break;
                    case 2:
                        //Instantiate(, BlockPosition, BlockRotation);
                        Debug.Log("CheckPoint2");
                        break;
                }
                
            }
            //this line decide the diffculty
            //there will be a helper function to calculate the spawning speed
            managerscript.ChangeHealth(damagerPerWave);
            managerscript.ChangeScore(1);
            managerscript.UpdateScore();
            yield return new WaitForSeconds(WaveWait);
        }
    }

    private void CreateList()
    {
        //create a list of blocks, recovers and empties
        for(i = 0;i < 7; i++)
        {
            System.Random num = new System.Random();
            j = num.Next(0, 2);
            ListSpawn.Insert(i, (int)UnityEngine.Random.Range(0.2f,2.7f));
            Debug.Log("This object is " + ListSpawn[i]);
            if (ListSpawn[i] == 0 && blocknum != 4)
            {
                blocknum++;
            }
            else if (blocknum ==4 && ListSpawn[i]==0)
            {
                ListSpawn.Insert(i, (int)UnityEngine.Random.Range(1, 2));

            }
        }
        //reset block count after created the whole list
        blocknum = 0;
    }
}
