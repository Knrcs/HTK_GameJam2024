using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CustomerLogic : MonoBehaviour
{

    public GameManager _gameManager;
    public GameObject moveSpots;
    private int rngTable;
    private int rngOrder;
    
    private GameObject customor;
    private GameObject exitPoint;
    public float moveSpeed = 0.01f;

    private bool _questComplete = false;
    [SerializeField] private bool _waitingCustomer;
    [SerializeField] private bool _tableAssigned;
    [SerializeField] private bool _waitingForOrder;
    [SerializeField] private bool _leaveTheStore;
    public bool leftRoom = false;
    private float _internalClock;
    public float clockValuemin;
    public float clockValuemax;
    public Image _itemSpriteRenderer;
    
    [Header("ItemsInHand")] 
    public bool bananaCanRay;
    public bool bananaBatterySniperShovel;
    public bool bananaBatterySniper;
    public bool bananaCanGatlin;
    public bool drillToasterSniperSpring;
    public bool drillCanRay;
    public bool drillGatlinShovel;
    public bool drillRayShovel;
    public bool dryerGatlinShovel;
    public bool dryerCanSniperSpring;
    public bool dryerCanRaySpartula;
    
    public Sprite bananaCanRaySprite;
    public Sprite bananaBatterySniperShovelSprite;
    public Sprite bananaCanGatlinSprite;
    public Sprite bananaBatterySniperSprite;
    public Sprite drillToasterSniperSpringSprite;
    public Sprite drillCanRaySprite;
    public Sprite drillGatlinShovelSprite;
    public Sprite drillRayShovelSprite;
    public Sprite dryerGatlinShovelSprite;
    public Sprite dryerCanSniperSpringSprite;
    public Sprite dryerCanRaySpartulaSprite;

    public List<Sprite> characterSprites = new List<Sprite>();
    private Sprite _currentSprite;
    private GameObject _customerOrder;
    private Image _orderSprite;

    private void Start()
    {
        _currentSprite = characterSprites[Random.Range(0, characterSprites.Count)];
        GetComponent<SpriteRenderer>().sprite = _currentSprite;
        _gameManager = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
        customor = this.GameObject();
        exitPoint = GameObject.Find("ExitPoint");
        rngTable = Random.Range(1, 4);
        rngOrder = Random.Range(1, 12);
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
            moveSpots.GetComponentInChildren<TextMeshProUGUI>().SetText(_currentSprite.name);
            if (moveSpots.name == "CustomerSpot11")
            {
                _customerOrder = GameObject.Find("CustomerOrder1");
            }
            else if (moveSpots.name == "CustomerSpot21")
            {
                _customerOrder = GameObject.Find("CustomerOrder2");
            }
            else if (moveSpots.name == "CustomerSpot31")
            {
                _customerOrder = GameObject.Find("CustomerOrder3");
            }
            
            _customerOrder.GetComponent<Animator>().Play("OrderPopInOut");
            _customerOrder.GetComponentInChildren<TextMeshProUGUI>().SetText(_currentSprite.name);
            _orderSprite = _customerOrder.GetComponentsInChildren<Image>()[1];
            _orderSprite.sprite = null;
        }
    }

    private void KillCustomer()
    {
        if (_leaveTheStore)
        {
            _customerOrder.GetComponent<Animator>().Play("OrderPopOut");
            
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

        if (other.gameObject.CompareTag("Table01"))
        {
            if (!_waitingForOrder)
            {
                AssignOrder();
                _waitingForOrder = true;
            }
        }
        if (other.gameObject.CompareTag("Table02"))
        {
            if (!_waitingForOrder)
            {
                AssignOrder();
                _waitingForOrder = true;

            }
        }
        if (other.gameObject.CompareTag("Table03"))
        {
            if (!_waitingForOrder)
            {
                AssignOrder();
                _waitingForOrder = true;

            }
        }

        if (other.gameObject.CompareTag("Customer"))
        {
            if (rngOrder == 1)
            {
                if (bananaCanRay)
                {
                    _itemSpriteRenderer.sprite = bananaCanRaySprite;
                }

                if (bananaBatterySniperShovel)
                {
                    _itemSpriteRenderer.sprite = bananaBatterySniperShovelSprite;
                }

                if (bananaBatterySniper)
                {
                    _itemSpriteRenderer.sprite = bananaCanGatlinSprite;
                }

                if (drillToasterSniperSpring)
                {
                    _itemSpriteRenderer.sprite = drillToasterSniperSpringSprite;
                }

                if (drillCanRay)
                {
                    _itemSpriteRenderer.sprite = drillCanRaySprite;
                }

                if (drillGatlinShovel)
                {
                    _itemSpriteRenderer.sprite = drillGatlinShovelSprite;
                }

                if (drillRayShovel)
                {
                    _itemSpriteRenderer.sprite = drillRayShovelSprite;
                }

                if (dryerGatlinShovel)
                {
                    _itemSpriteRenderer.sprite = dryerGatlinShovelSprite;
                }

                if (dryerCanRaySpartula)
                {
                    _itemSpriteRenderer.sprite = dryerCanRaySpartulaSprite;
                }

                if (dryerCanSniperSpring)
                {
                    _itemSpriteRenderer.sprite = dryerCanSniperSpringSprite;
                }

                if (bananaCanGatlin)
                {
                    _itemSpriteRenderer.sprite = bananaCanGatlinSprite;
                }
            }
  
        }
    }

    private void AssignOrder()
    {
        switch (rngOrder)
        {
            case 1:
                bananaCanRay = true;
                break;
            case 2:
                bananaBatterySniperShovel = true;
                break;
            case 3:
                bananaBatterySniper = true;
                break;
            case 4:
                drillToasterSniperSpring = true;
                break;
            case 5:
                drillCanRay = true;
                break;
            case 6:
                drillGatlinShovel = true;
                break;
            case 7:
                drillRayShovel = true;
                break;
            case 8:
                dryerGatlinShovel = true;
                break;
            case 9:
                dryerCanRaySpartula = true;
                break;
            case 10:
                dryerCanSniperSpring = true;
                break;
            case 11:
                bananaCanGatlin = true;
                break;
        }
    }
}
