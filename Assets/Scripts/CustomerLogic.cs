using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerLogic : MonoBehaviour
{

    public GameManager _gameManager;
    public GameObject moveSpots;
    private int rngTable;
    
    private GameObject customor;
    private GameObject exitPoint;
    public float moveSpeed = 0.01f;

    private bool _questComplete = false;
    [SerializeField] private bool _waitingCustomer;
    [SerializeField] private bool _tableAssigned;
    [SerializeField] private bool _leaveTheStore;
    public bool leftRoom = false;
    private float _internalClock;
    public float clockValuemin;
    public float clockValuemax;
    

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
        customor = this.GameObject();
        exitPoint = GameObject.Find("ExitPoint");
        rngTable = Random.Range(1, 3);
        SelectTable(rngTable);
        _questComplete = false;
        _waitingCustomer = true;
    }

    private void SelectTable(int spots)
    {
        switch (spots)
        {
            case 1:
                moveSpots = GameObject.FindGameObjectWithTag("Table01");
                break;
            case 2:
                moveSpots = GameObject.FindGameObjectWithTag("Table02");
                break;
            case 3:
                moveSpots = GameObject.FindGameObjectWithTag("Table03");
                break;
        }
        
    }

    private void Update()
    {
        if (_internalClock < 0)
        {
            CustomerAI();
            _internalClock = Random.Range(clockValuemin, clockValuemax);
        }

        _internalClock -= Time.deltaTime;
        CustomerMove();
        KillCustomer();
    }

    private void CustomerAI()
    {
        if (_waitingCustomer)
        {
            Debug.Log("Customer looking for space");
            
            if (rngTable == 1 && !_gameManager.table01)
            {
                Debug.Log("Table assigned?");

                _waitingCustomer = false;
                _gameManager.table01 = true;
                _tableAssigned = true;
            }
            else if (rngTable == 2 && !_gameManager.table02)
            {
                Debug.Log("Table assigned?");
                _waitingCustomer = false;
                _gameManager.table02 = true;
                _tableAssigned = true;
            }
            else if (rngTable == 3 && !_gameManager.table03)
            {
                Debug.Log("Table assigned?");

                _waitingCustomer = false;
                _gameManager.table03 = true;
                _tableAssigned = true;
            }
        }

        
    }

    private void CustomerMove()
    {
        if (_tableAssigned)
        {
            customor.transform.position = Vector2.MoveTowards(customor.transform.position, moveSpots.transform.position, moveSpeed);
        }
    }

    private void KillCustomer()
    {
        if (_leaveTheStore)
        {
            _tableAssigned = false;
            customor.transform.position = Vector2.MoveTowards(customor.transform.position, exitPoint.transform.position, moveSpeed);
            if(leftRoom)
            {
                switch (rngTable)
                {
                    case 1:
                        _gameManager.table01 = false;
                        break;
                    case 2:
                        _gameManager.table02 = false;
                        break;
                    case 3:
                        _gameManager.table03 = false;
                        break;
                
                }
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collisison happened");

        if (other.gameObject.CompareTag("Exit"))
        {
            if (_leaveTheStore)
            {
                leftRoom = true;
            }
        }
    }
}
