using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;

    public float spawnTimer;
    private float _spawnTimerDefault;
    public float spawnTimerCap;
    public float difficulty;
    public int _customerLimit = 1;
    public GameObject customerSpawn;


    private void Start()
    {
        _spawnTimerDefault = spawnTimer;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;


        if (_customerLimit < 3)
        {
            if (spawnTimer <= 0 && transform.childCount <= 3)
            {
                Instantiate(customerPrefab, customerSpawn.transform);
                _customerLimit++;
                spawnTimer = _spawnTimerDefault;
                if (_spawnTimerDefault !>= spawnTimerCap)
                {
                    Debug.Log("Difficulty Increased: " + _spawnTimerDefault);
                    _spawnTimerDefault =  _spawnTimerDefault * difficulty;
                }
            }
        }

    }
    
    
}
