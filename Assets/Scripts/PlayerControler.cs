using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    private InputAction _interactAction;
    private Animator _animator;
    public GameObject _isInteractable;
    private GameManager _gameManager;
    public int health;
    public SpriteRenderer handItem;

    public bool handSlot;

    [Header("Body Item")] 
    [SerializeField] public bool _drill;
    [SerializeField] public bool _hairDryer;
    [SerializeField] public bool _banana;

    [Header("Magazin Item")] 
    [SerializeField] public bool _toaster;
    [SerializeField] public bool _can;
    [SerializeField] public bool _battery;

    [Header("Barrel Item")] 
    [SerializeField] public bool _raygun;
    [SerializeField] public bool _gatlin;
    [SerializeField] public bool _sniperBarrel;

    [Header("Stock Item")] 
    [SerializeField] public bool _spartula;
    [SerializeField] public bool _shovel;
    [SerializeField] public bool _spring;

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

    [Header("Sprite Collection")] 
    public Sprite drillSprite;
    public Sprite hairDryerSprite;
    public Sprite bananaSprite;
    public Sprite toasterSprite;
    public Sprite canSprite;
    public Sprite batterySprite;
    public Sprite raygunSprite;
    public Sprite gatlinSprite;
    public Sprite sniperSprite;
    public Sprite spartulaSprite;
    public Sprite shovelSprite;
    public Sprite springSprite;

    public Sprite bananaCanRaySprite;
    public Sprite bananaBatterySniperShovelSprite;
    public Sprite bananaBatterySniperSprite;
    public Sprite bananaCangatlinSprite;
    public Sprite drillToasterSniperSpringSprite;
    public Sprite drillCanRaySprite;
    public Sprite drillGatlinShovelSprite;
    public Sprite drillRayShovelSprite;
    public Sprite dryerGatlinShovelSprite;
    public Sprite dryerCanSniperSpringSprite;
    public Sprite dryerCanRaySpartulaSprite;
    
    

    private void Start()
    {
        _gameManager = GameObject.FindWithTag("Gamemanager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (health == 0)
        {
            _gameManager.EndScreenValues();
        }
        ReplaceItemsInHand();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            NotifyPlayer(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            NotifyPlayer(false);
        }
    }

    private void NotifyPlayer(bool state)
    {
        _isInteractable.SetActive(state);
    }

    private void ReplaceItemsInHand()
    {
        if (_drill)
        {
            handItem.sprite = drillSprite;
        } 
        else if (_hairDryer)
        {
            handItem.sprite = hairDryerSprite;
        }
        else if (_banana)
        {
            handItem.sprite = bananaSprite;
        }
        else if (_toaster)
        {
            handItem.sprite = toasterSprite;
        }
        else if (_raygun)
        {
            handItem.sprite = raygunSprite;
        }
        else if (_gatlin)
        {
            handItem.sprite = gatlinSprite;
        }
        else if (_sniperBarrel)
        {
            handItem.sprite = sniperSprite;
        }
        else if (_spartula)
        {
            handItem.sprite = spartulaSprite;
        }
        else if (_shovel)
        {
            handItem.sprite = shovelSprite;
        }
        else if (_can)
        {
            handItem.sprite = canSprite;
        }
        else if (_battery)
        {
            handItem.sprite = batterySprite;
        }
        else if (_spring)
        {
            handItem.sprite = springSprite;
        }
        else if (bananaCanRay)
        {
            handItem.sprite = bananaCanRaySprite;
        }
        else if (bananaBatterySniperShovel)
        {
            handItem.sprite = bananaBatterySniperShovelSprite;
        }
        else if (bananaBatterySniper)
        {
            handItem.sprite = bananaBatterySniperSprite;
        }
        else if (bananaCanGatlin)
        {
            handItem.sprite = bananaCangatlinSprite;
        }
        else if (drillToasterSniperSpring)
        {
            handItem.sprite = drillToasterSniperSpringSprite;
        }
        else if (drillCanRay)
        {
            handItem.sprite = drillCanRaySprite;
        }
        else if (drillGatlinShovel)
        {
            handItem.sprite = drillGatlinShovelSprite;
        }
        else if (drillRayShovel)
        {
            handItem.sprite = drillRayShovelSprite;
        }
        else if (dryerGatlinShovel)
        {
            handItem.sprite = dryerGatlinShovelSprite;
        }
        else if (dryerCanSniperSpring)
        {
            handItem.sprite = dryerCanSniperSpringSprite;
        }
        else if (dryerCanRaySpartula)
        {
            handItem.sprite = dryerCanRaySpartulaSprite;
        }
        else
        {
            handItem.sprite = null;
        }

    }

    public void ClearHand()
    {
        bananaCanRay = false;
        bananaBatterySniperShovel = false;
        bananaBatterySniper = false;
        bananaCanGatlin = false;
        drillToasterSniperSpring = false;
        drillCanRay = false;
        drillGatlinShovel = false;
        drillRayShovel = false;
        dryerGatlinShovel = false;
        dryerCanSniperSpring = false;
        dryerCanRaySpartula = false;

        _drill = false;
        _hairDryer = false;
        _banana = false;

        _toaster = false;
        _can = false;
        _battery = false;

        _raygun = false;
        _gatlin = false;
        _sniperBarrel = false;

        _spartula = false;
        _shovel = false;
        _spring = false;

        handSlot = false;
    }
        
}

