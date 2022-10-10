using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenSecondsTimer : MonoBehaviour
{
    [SerializeField]
    int totalPhasesInLevel;

    private int phaseCounter = 0;

    private float phaseTime = 2f;
    private float remainingTime;

    private void Start()
    {
        remainingTime = phaseTime;
    }

    void Update()
    {
        if(remainingTime < 0)
        {
            WallMovement[] movingWalls = FindObjectsOfType<WallMovement>();
            foreach(WallMovement wall in movingWalls)
            {
                wall.moveWall(phaseCounter % totalPhasesInLevel);
            }

            phaseCounter++;

            remainingTime = phaseTime;
        }
        
        remainingTime -= Time.deltaTime;
    }
}
