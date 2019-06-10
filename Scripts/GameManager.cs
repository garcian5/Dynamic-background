using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int scoreValue;
    public int maxHealth = 1000;
    private int playerHealth;
    public Text HealthText;

    void Start()
    {
        scoreValue = 0;
        playerHealth = maxHealth;
    }

    //increase score when the player hit recovery
    public void ChangeScore(int value)
    {
        scoreValue += value;
    }

    public void ChangeHealth(int value)
    {

        playerHealth = Mathf.Clamp((playerHealth+=value),0,maxHealth);
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public float getHealthPercent()
    {
        return (float)playerHealth / maxHealth;
    }

    public bool IsDeath()
    {
        return playerHealth == 0;
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        //Debug.Log("The health is " + playerHealth);
        HealthText.text = "" + playerHealth;
    }
}
