using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private GameManager ManagerScript;

    public void updateHealth()
    {
        GameObject Man = GameObject.FindGameObjectWithTag("GameController");
        if (Man != null)
        {
            ManagerScript = Man.GetComponent<GameManager>();
        }
        transform.Find("Bar").localScale = new Vector3(ManagerScript.getHealthPercent(), 1);
    }

    void Update()
    {
        updateHealth();
    }
}
