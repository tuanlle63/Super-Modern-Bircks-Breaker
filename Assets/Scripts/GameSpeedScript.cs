using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Time.timeScale = 0.5f;
        }else if (Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale = 1.0f;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            Time.timeScale = 1.5f;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            Time.timeScale = 2.0f;
        }
    }
}
