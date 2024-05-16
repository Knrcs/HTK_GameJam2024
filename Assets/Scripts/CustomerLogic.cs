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
    public CustomerScore customerScore;
    private int rngTable;
    private int rngOrder;
    
    private GameObject customor;
    private GameObject exitPoint;
    public float moveSpeed = 0.01f;

    private bool _questComplete = false;
    [SerializeField] private bool _waitingCustomer;
    [SerializeField] private bool _tableAssigned;
    public bool _waitingForOrder;
    public bool _leaveTheStore;
    private CustomerSpawner _customerSpawner;
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
    private Image _fillSprite;
    private Sprite _currentGunRequested;
    private bool _startMoving = false;
    
    public float sizeMultiplier;
    private bool _dontScale;

    private void Start()
    {
        GetComponent<Animator>().Play("FadeInAnimation");
        
        _currentSprite = characterSprites[Random.Range(0, characterSprites.Count)];
        GetComponent<SpriteRenderer>().sprite = _currentSprite;
        _gameManager = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
        customor = this.GameObject();
        exitPoint = GameObject.Find("ExitPoint");
        rngTable = Random.Range(1, 4);
        rngOrder = Random.Range(1, 12);
        //SelectTable(rngTable);
        _questComplete = false;
        _waitingCustomer = true;
        _customerSpawner = GameObject.Find("CustomerSpawner").GetComponent<CustomerSpawner>();
        customerScore = gameObject.GetComponent<CustomerScore>();

    }

    private void FadeInOver() { _startMoving = true; }

    /*
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
    */


    private void Update()
    {
        if (_internalClock < 0)
        {
            CustomerAI();
            _internalClock = Random.Range(clockValuemin, clockValuemax);
        }

        _internalClock -= Time.deltaTime;
        if (_startMoving)
        {
            CustomerMove();
        }
        KillCustomer();
    }

    private void CustomerAI()
    {
        if (_waitingCustomer)
        {
            if (!_gameManager.table01)
            {
                _waitingCustomer = false;
                _gameManager.table01 = true;
                _tableAssigned = true;
                moveSpots = GameObject.FindGameObjectWithTag("Table01");
                customor.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (!_gameManager.table02)
            {
                _waitingCustomer = false;
                _gameManager.table02 = true;
                _tableAssigned = true;
                moveSpots = GameObject.FindGameObjectWithTag("Table02");
                customor.GetComponent<SpriteRenderer>().sortingOrder = -1;
            }
            else if (!_gameManager.table03)
            {
                _waitingCustomer = false;
                _gameManager.table03 = true;
                _tableAssigned = true;
                moveSpots = GameObject.FindGameObjectWithTag("Table03");
                customor.GetComponent<SpriteRenderer>().sortingOrder = -2;
            }
            
            /*
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
            else
            {
                rngTable = Random.Range(1, 4);
                SelectTable(rngTable);
            }
            */
        }

        
    }

    private void CustomerMove()
    {
        if (_tableAssigned)
        {
            customor.transform.position = Vector2.MoveTowards(customor.transform.position, moveSpots.transform.position, moveSpeed);
            CustomerBiggerAndSmaller();
        }
    }

    private void CustomerBiggerAndSmaller()
    {
        if (!_dontScale)
        {
            if (_tableAssigned)
            {
                transform.localScale *= sizeMultiplier;
            }
            else if (_leaveTheStore)
            {
                transform.localScale /= sizeMultiplier;
            }
        }
    }

    private void SetOrderUI()
    {
        Debug.Log(moveSpots);
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

        _dontScale = true;
        _customerOrder.GetComponentInChildren<TextMeshProUGUI>().SetText(_currentSprite.name);
        _orderSprite = _customerOrder.GetComponentsInChildren<Image>()[1];
        _orderSprite.sprite = _currentGunRequested;
        _customerOrder.GetComponent<Animator>().Play("OrderPopInOut");
    }

    private void KillCustomer()
    {
        if (_leaveTheStore)
        {
            _dontScale = false;
            _customerOrder.GetComponent<Animator>().Play("OrderPopOut");
            moveSpots.GetComponentInChildren<TextMeshProUGUI>().SetText("");
            
            _tableAssigned = false;
            customor.transform.position = Vector2.MoveTowards(customor.transform.position, exitPoint.transform.position, moveSpeed);
            CustomerBiggerAndSmaller();
            if(leftRoom)
            {
                _dontScale = true;
                
                /*switch (rngTable)
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
                
                }*/
                if (moveSpots.name == "CustomerSpot11")
                {
                    _gameManager.table01 = false;
                }
                else if (moveSpots.name == "CustomerSpot21")
                {
                    _gameManager.table02 = false;
                }
                else if (moveSpots.name == "CustomerSpot31")
                {
                    _gameManager.table03 = false;
                }
                
                GetComponent<Animator>().Play("FadeOutAnimation");
            }
        }
    }

    private void DeleteCustomer()
    {
        _customerSpawner._customerLimit--;
        Destroy(customor);
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
                customerScore.GetOrderCard();
                _waitingForOrder = true;
            }
        }
        if (other.gameObject.CompareTag("Table02"))
        {
            if (!_waitingForOrder)
            {
                customerScore.GetOrderCard();
                AssignOrder();
                _waitingForOrder = true;

            }
        }
        if (other.gameObject.CompareTag("Table03"))
        {
            if (!_waitingForOrder)
            {
                AssignOrder();
                customerScore.GetOrderCard();
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
                _currentGunRequested = bananaCanRaySprite;
                break;
            case 2:
                bananaBatterySniperShovel = true;
                _currentGunRequested = bananaBatterySniperShovelSprite;
                break;
            case 3:
                bananaBatterySniper = true;
                _currentGunRequested = bananaBatterySniperSprite;
                break;
            case 4:
                drillToasterSniperSpring = true;
                _currentGunRequested = drillToasterSniperSpringSprite;
                break;
            case 5:
                drillCanRay = true;
                _currentGunRequested = drillCanRaySprite;
                break;
            case 6:
                drillGatlinShovel = true;
                _currentGunRequested = drillGatlinShovelSprite;
                break;
            case 7:
                drillRayShovel = true;
                _currentGunRequested = drillRayShovelSprite;
                break;
            case 8:
                dryerGatlinShovel = true;
                _currentGunRequested = dryerGatlinShovelSprite;
                break;
            case 9:
                dryerCanRaySpartula = true;
                _currentGunRequested = dryerCanRaySpartulaSprite;
                break;
            case 10:
                dryerCanSniperSpring = true;
                _currentGunRequested = dryerCanSniperSpringSprite;
                break;
            case 11:
                bananaCanGatlin = true;
                _currentGunRequested = bananaCanGatlinSprite;
                break;
        }
        SetOrderUI();
    }
}
