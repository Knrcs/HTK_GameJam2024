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
    public bool pickThatBooty;

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

    public void ItemInCraftingTable()
    {
        if (!_bodyPartUsed)
        {
            if (_playerControler._drill)
            {
                _drill = _playerControler._drill;
                _bodyPartUsed = true;
                bodySpriteObject.sprite = drillSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Drill");
            }
            if(_playerControler._hairDryer)
            {       
                _hairDryer = _playerControler._hairDryer;
                _bodyPartUsed = true;
                bodySpriteObject.sprite = dryerSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Hairdryer");
            }
            if (_playerControler._banana)
            {
                _banana = _playerControler._banana;
                _bodyPartUsed = true;
                bodySpriteObject.sprite = bananaSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Banana");
            } 
        }


        if (!_magazinPartUsed)
        {
            if (_playerControler._toaster)
            {
                _toaster = _playerControler._toaster;
                _magazinPartUsed = true;
                magazinSpriteObject.sprite = toasterSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Toaster");
            }

            if (_playerControler._can)
            {
                _can = _playerControler._can;
                _magazinPartUsed = true;
                magazinSpriteObject.sprite = canSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Can");
            }

            if (_playerControler._battery)
            {
                _battery = _playerControler._battery;
                _magazinPartUsed = true;
                magazinSpriteObject.sprite = batterySprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Battery");
            }   
        }


        if (!_barrelPartUsed)
        {
            if (_playerControler._raygun)
            {
                _raygun = _playerControler._raygun;
                _barrelPartUsed = true;
                barrelSpriteObject.sprite = raygunSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/RayGun");
            }

            if (_playerControler._gatlin)
            {
                _gatlin = _playerControler._gatlin;
                _barrelPartUsed = true;
                barrelSpriteObject.sprite = gatlinSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/GatlingGun");
            }

            if (_playerControler._sniperBarrel)
            {
                _sniperBarrel = _playerControler._sniperBarrel;
                _barrelPartUsed = true;
                barrelSpriteObject.sprite = sniperSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Sniper");
            }
        }


        if (!_stockPartUsed)
        {
            if (_playerControler._spartula)
            {
                _spartula = _playerControler._spartula;
                _stockPartUsed = true;
                stockSpriteObject.sprite = spartulaSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Spatula");
            }
            if (_playerControler._shovel)
            {
                _shovel = _playerControler._shovel;
                _stockPartUsed = true;
                stockSpriteObject.sprite = shovelSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Shovel");
            }
            if (_playerControler._spring)
            {
                _spring = _playerControler._spring;
                _stockPartUsed = true;
                stockSpriteObject.sprite = springSprite;
                GameManager.instance.PlayThisOneShot("event:/SFX/Items/Spring");
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
        if (!_playerControler.handSlot)
        {
            Debug.Log(_playerControler.handSlot);
            
            if (_banana && _can && _raygun)
            {
                pickThatBooty = true;
                bananaCanRay = true;
                resultSpriteObject.sprite = bananaCanRaySprite;
                ClearCraftingTable();
                LogItemCrafted("Banana Can Raygun");
                CraftingSuccessSound();
            }
            else if (_drill && _can && _raygun)
            {
                pickThatBooty = true;
                drillCanRay = true;
                resultSpriteObject.sprite = drillCanRaySprite;
                ClearCraftingTable();
                LogItemCrafted("Drill Can Raygun");
                CraftingSuccessSound();
            }
            else if (_drill && _gatlin && _shovel)
            {
                pickThatBooty = true;
                drillGatlinShovel = true;
                resultSpriteObject.sprite = drillGatlinShovelSprite;
                ClearCraftingTable();
                LogItemCrafted("Drill Gatlin Shovel");
                CraftingSuccessSound();
            }
            else if (_drill && _raygun && _shovel)
            {
                pickThatBooty = true;
                drillRayShovel = true;
                resultSpriteObject.sprite = drillRayShovelSprite;
                ClearCraftingTable();
                LogItemCrafted("Drill Gatlin Shovel");
                CraftingSuccessSound();
            }
            else if (_drill && _sniperBarrel && _spring && _toaster)
            {
                pickThatBooty = true;
                drillToasterSniperSpring = true;
                resultSpriteObject.sprite = drillToasterSniperSpringSprite;
                ClearCraftingTable();
                LogItemCrafted("Drill Toaster Sniper Spring");
                CraftingSuccessSound();
            }
            else if (_hairDryer && _can && _sniperBarrel && _spring)
            {
                pickThatBooty = true;
                dryerCanSniperSpring = true;
                resultSpriteObject.sprite = dryerCanSniperSpringSprite;
                ClearCraftingTable();
                LogItemCrafted("Dryer can Sniper Spring");
                CraftingSuccessSound();
            }
            else if (_hairDryer && _can && _spartula && _raygun)
            {
                pickThatBooty = true;
                dryerCanRaySpartula = true;
                resultSpriteObject.sprite = dryerCanRaySpartulaSprite;
                ClearCraftingTable();
                LogItemCrafted("Dryer Can Spartula Raygun");
                CraftingSuccessSound();
            }
            else if (_hairDryer && _gatlin && _shovel)
            {
                pickThatBooty = true;
                dryerGatlinShovel = true;
                resultSpriteObject.sprite = dryerGatlinShovelSprite;
                ClearCraftingTable();
                LogItemCrafted("Dryer Gatlin Shovel");
                CraftingSuccessSound();
            }
            else if (_banana && _battery && _sniperBarrel)
            {
                pickThatBooty = true;
                bananaBatterySniper = true;
                resultSpriteObject.sprite = bananaBatterySniperSprite;
                ClearCraftingTable();
                LogItemCrafted("Banana Battery Sniper Rifle");
                CraftingSuccessSound();
            }
            else if (_banana && _battery && _sniperBarrel && _shovel)
            {
                pickThatBooty = true;
                bananaBatterySniperShovel = true;
                resultSpriteObject.sprite = bananaBatterySniperShovelSprite;
                ClearCraftingTable();
                LogItemCrafted("Banana Battery Sniper Rifle");
                CraftingSuccessSound();
            }
            else if (_banana && _can && _gatlin)
            {
                pickThatBooty = true;
                bananaCanGatlin = true;
                resultSpriteObject.sprite = bananaCanGatlinSprite;
                ClearCraftingTable();
                LogItemCrafted("Banana Battery Sniper Rifle");
                CraftingSuccessSound();
            }
            else
            {

                GameManager.instance.PlayThisOneShot("event:/SFX/Other/DeletingItems");
                
                ClearCraftingTable();
                LogItemCrafted("Null");
            }
        }
    }

    private void CraftingSuccessSound()
    {
        GameManager.instance.PlayThisOneShot("event:/SFX/Other/Crafting");
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
        
        _bodyPartUsed = false;
        _magazinPartUsed = false;
        _barrelPartUsed = false;
        _stockPartUsed = false;
    }

    private void PickUpCraftingTable()
    {
        _bodyPartUsed = false;
        _magazinPartUsed = false;
        _barrelPartUsed = false;
        _stockPartUsed = false;
        resultSpriteObject.sprite = null;

        pickThatBooty = false;
    }

    public void PickUpResult()
    {
        if (pickThatBooty)
        {
            if (bananaCanRay)
            {
                PickUpCraftingTable();
                bananaCanRay = false;
                _playerControler.bananaCanRay = true;
            }
            if (bananaBatterySniperShovel)
            {
                PickUpCraftingTable();
                bananaBatterySniperShovel = false;
                _playerControler.bananaBatterySniperShovel = true;
            }
            if (bananaBatterySniper)
            {
                PickUpCraftingTable();
                bananaBatterySniper = false;
                _playerControler.bananaBatterySniper = true;
            }
            if (bananaCanGatlin)
            {
                PickUpCraftingTable();
                bananaCanGatlin = false;
                _playerControler.bananaCanGatlin = true;
            }
            if (drillToasterSniperSpring)
            {
                PickUpCraftingTable();
                drillToasterSniperSpring = false;
                _playerControler.drillToasterSniperSpring = true;
            }
            if (drillCanRay)
            {
                PickUpCraftingTable();
                drillCanRay = false;
                _playerControler.drillCanRay = true;
            }
            if (drillRayShovel)
            {
                PickUpCraftingTable();
                drillRayShovel = false;
                _playerControler.drillRayShovel = true;
            }
            if (dryerGatlinShovel)
            {
                PickUpCraftingTable();
                dryerGatlinShovel = false;
                _playerControler.dryerGatlinShovel = true;
            }
            if (dryerCanSniperSpring)
            {
                PickUpCraftingTable();
                dryerCanSniperSpring = false;
                _playerControler.dryerCanSniperSpring = true;
            }
            if (dryerCanRaySpartula)
            {
                PickUpCraftingTable();
                dryerCanRaySpartula = false;
                _playerControler.dryerCanRaySpartula = true;
            }
            
            
        }
        else return;
    }
}
