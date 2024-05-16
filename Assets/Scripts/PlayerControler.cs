using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private InputAction _interactAction;
    private Animator _animator;
    public GameObject _isInteractable;
    private GameManager _gameManager;
    public int health;

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
    }
        
}

