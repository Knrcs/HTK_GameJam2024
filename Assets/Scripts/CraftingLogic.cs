using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingLogic : MonoBehaviour
{
    [Header("Crafting")] public PlayerControler _playerControler;
    [SerializeField] private bool _bodyPartUsed;
    [SerializeField] private bool _magazinPartUsed;
    [SerializeField] private bool _barrelPartUsed;
    [SerializeField] private bool _stockPartUsed;

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

    [Header("Sprite Objects")] 
    public SpriteRenderer bodySpriteObject;
    public SpriteRenderer magazinSpriteObject;
    public SpriteRenderer barrelSpriteObject;
    public SpriteRenderer stockSpriteObject;
    public SpriteRenderer resultSpriteObject;

    [Header("Sprite Library")] 
    public Sprite bananaSprite;
    public Sprite drillSprite;
    public Sprite dryerSprite;

    public Sprite toasterSprite;
    public Sprite batterySprite;
    public Sprite canSprite;
    
    public Sprite raygunSprite;
    public Sprite gatlinSprite;
    public Sprite sniperSprite;
    
    public Sprite spartulaSprite;
    public Sprite shovelSprite;
    public Sprite springSprite;
    
    [Header("Sprite Library - Weapons")]
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

    [Header("Item Library")] 
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
    



    private void Update()
    {
        
    }

    public void ItemInCraftingTable()
    {
        if (!_bodyPartUsed)
        {
            if (_playerControler._drill)
            {
                _drill = _playerControler._drill;
                _bodyPartUsed = true;
                bodySpriteObject.sprite = drillSprite;
            }
            if(_playerControler._hairDryer)
            {       
                _hairDryer = _playerControler._hairDryer;
                _bodyPartUsed = true;
                bodySpriteObject.sprite = dryerSprite;
            }
            if (_playerControler._banana)
            {
                _banana = _playerControler._banana;
                _bodyPartUsed = true;
                bodySpriteObject.sprite = bananaSprite;
            } 
        }


        if (!_magazinPartUsed)
        {
            if (_playerControler._toaster)
            {
                _toaster = _playerControler._toaster;
                _magazinPartUsed = true;
                magazinSpriteObject.sprite = toasterSprite;
            }

            if (_playerControler._can)
            {
                _can = _playerControler._can;
                _magazinPartUsed = true;
                magazinSpriteObject.sprite = canSprite;
            }

            if (_playerControler._battery)
            {
                _battery = _playerControler._battery;
                _magazinPartUsed = true;
                magazinSpriteObject.sprite = batterySprite;
            }   
        }


        if (!_barrelPartUsed)
        {
            if (_playerControler._raygun)
            {
                _raygun = _playerControler._raygun;
                _barrelPartUsed = true;
                barrelSpriteObject.sprite = raygunSprite;
            }

            if (_playerControler._gatlin)
            {
                _gatlin = _playerControler._gatlin;
                _barrelPartUsed = true;
                barrelSpriteObject.sprite = gatlinSprite;
            }

            if (_playerControler._sniperBarrel)
            {
                _sniperBarrel = _playerControler._sniperBarrel;
                _barrelPartUsed = true;
                barrelSpriteObject.sprite = sniperSprite;
            }
        }


        if (!_stockPartUsed)
        {
            if (_playerControler._spartula)
            {
                _spartula = _playerControler._spartula;
                _stockPartUsed = true;
                stockSpriteObject.sprite = spartulaSprite;
            }
            if (_playerControler._shovel)
            {
                _shovel = _playerControler._shovel;
                _stockPartUsed = true;
                stockSpriteObject.sprite = shovelSprite;
            }
            if (_playerControler._spring)
            {
                _spring = _playerControler._spring;
                _stockPartUsed = true;
                stockSpriteObject.sprite = springSprite;
            }   
        }

        
        ClearHandSlot();
    }

    public void ClearHandSlot()
    {
        _playerControler.handSlot = false;
        
        _playerControler._drill = false;
        _playerControler._hairDryer = false;
        _playerControler._banana = false;
        
        _playerControler._toaster = false;
        _playerControler._can = false;
        _playerControler._battery = false;
        
        _playerControler._raygun = false;
        _playerControler._gatlin = false;
        _playerControler._sniperBarrel = false;
        
        _playerControler._spartula = false;
        _playerControler._shovel = false;
        _playerControler._spring = false;
    }

    #region PickupItem Function

    public void PickupDrill()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._drill = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    
    public void PickupHairDryer()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._hairDryer = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    
    public void PickupBanana()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._banana = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    
    public void PickupToaster()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._toaster = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    
    public void PickupCan()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._can = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    
    public void PickupBattery()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._battery = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    public void PickupRayGun()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._raygun = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    public void PickupGatlin()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._gatlin = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    public void PickupSniperBarrel()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._sniperBarrel = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    public void PickupSpartula()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._spartula = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    public void PickupShovel()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._shovel = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }
    
    public void PickupSpring()
    {
        if (!_playerControler.handSlot)
        {
            _playerControler._spring = true;
            _playerControler.handSlot = true;
        }
        else
        {
            CantPickUp();
        }
    }









    private void CantPickUp()
    {
        //TODO: Error play sound
    }

    #endregion

    public void CraftThatBooty()
    {
        if (_banana && _can && _raygun)
        {
            //TODO: Success Sound
            bananaCanRay = true;
            resultSpriteObject.sprite = bananaCanRaySprite;
            ClearCraftingTable();
            LogItemCrafted("Banana Can Raygun");
        }

        if (_drill && _can && _raygun)
        {
            drillCanRay = true;
            resultSpriteObject.sprite = drillCanRaySprite;
            ClearCraftingTable();
            LogItemCrafted("Drill Can Raygun");
        }

        if (_drill && _gatlin && _shovel)
        {
            drillGatlinShovel = true;
            resultSpriteObject.sprite = drillGatlinShovelSprite;
            ClearCraftingTable();
            LogItemCrafted("Drill Gatlin Shovel");
        }
        if (_drill && _raygun && _shovel)
        {
            drillRayShovel = true;
            resultSpriteObject.sprite = drillRayShovelSprite;
            ClearCraftingTable();
            LogItemCrafted("Drill Gatlin Shovel");
        }
        if (_drill && _sniperBarrel && _spring && _toaster)
        {
            drillToasterSniperSpring = true;
            resultSpriteObject.sprite = drillToasterSniperSpringSprite;
            ClearCraftingTable();
            LogItemCrafted("Drill Toaster Sniper Spring");
        }

        if (_hairDryer && _can && _sniperBarrel && _spring)
        {
            dryerCanSniperSpring = true;
            resultSpriteObject.sprite = dryerCanSniperSpringSprite;
            ClearCraftingTable();
            LogItemCrafted("Dryer can Sniper Spring");
        }

        if (_hairDryer && _can && _spartula && _raygun)
        {
            dryerCanRaySpartula = true;
            resultSpriteObject.sprite = dryerCanRaySpartulaSprite;
            ClearCraftingTable();
            LogItemCrafted("Dryer Can Spartula Raygun");
        }

        if (_hairDryer && _gatlin && _shovel)
        {
            dryerGatlinShovel = true;
            resultSpriteObject.sprite = dryerGatlinShovelSprite;
            ClearCraftingTable();
            LogItemCrafted("Dryer Gatlin Shovel");  
        }

        if (_banana && _battery && _sniperBarrel)
        {
            bananaBatterySniper = true;
            resultSpriteObject.sprite = bananaBatterySniperSprite;
            ClearCraftingTable();
            LogItemCrafted("Banana Battery Sniper Rifle");  
        }
        if (_banana && _battery && _sniperBarrel && _shovel)
        {
            bananaBatterySniperShovel = true;
            resultSpriteObject.sprite = bananaBatterySniperShovelSprite;
            ClearCraftingTable();
            LogItemCrafted("Banana Battery Sniper Rifle");  
        }
        if (_banana && _can && _gatlin)
        {
            bananaCanGatlin = true;
            resultSpriteObject.sprite = bananaCanGatlinSprite;
            ClearCraftingTable();
            LogItemCrafted("Banana Battery Sniper Rifle");  
        }
        else
        {
            //TODO: Fail Sound
            ClearCraftingTable();
            LogItemCrafted("Null");
        }
    }

    private void LogItemCrafted(string text)
    {
        Debug.Log("Item: " + text + " crafted!");
    }
    private void ClearCraftingTable()
    {
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

        bodySpriteObject.sprite = null;
        magazinSpriteObject.sprite = null;
        barrelSpriteObject.sprite = null;
        stockSpriteObject.sprite = null;
    }

    private void PickUpResult()
    {
        
    }
}
