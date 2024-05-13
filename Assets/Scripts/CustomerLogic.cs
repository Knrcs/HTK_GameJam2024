using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerLogic : MonoBehaviour
{
    public GameObject[] moveSpots;
    private int rngTable;

    private void Start()
    {
        rngTable = Random.Range(1, 3);
        SelectTable(rngTable);
    }

    private void SelectTable(int spots)
    {
        switch (spots)
        {
            case 1:
                moveSpots = GameObject.FindGameObjectsWithTag("Table01");
                break;
            case 2:
                moveSpots = GameObject.FindGameObjectsWithTag("Table02");
                break;
            case 3:
                moveSpots = GameObject.FindGameObjectsWithTag("Table03");
                break;
        }
        
    }
    
}
