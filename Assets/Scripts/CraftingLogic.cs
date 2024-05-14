using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingLogic : MonoBehaviour
{
    [Header("Crafting")] 
    [SerializeField] private int _bodyPart = 0;
    //1 Drill
    //2 Hairdryer
    //3 Banana
    [SerializeField] private int magazin = 0;
    //1 Toaster
    //2 Can
    //3 Battery
    [SerializeField] private int barrel = 0;
    //1 Raygun
    //2 Gatlin
    //3 Sniper barrel
    [SerializeField] private int stock = 0;
    //1 Spatula
    //2 Shovel
    //3 Spring
    
    private string recipe;

    public void crafting()
    {
        //All possible Crafting recipe
        //1,1,1,1 
        //2,1,1,1
        //3,1,1,1
        //3,2,1,1
        
    }
}
