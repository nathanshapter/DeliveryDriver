using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapIcons : MonoBehaviour
{
    [SerializeField] public SpriteRenderer[] dillwynniaIcons, seventhAve, rueStJacques, northWest, easternLowlands
        ;
    DeliveryManager deliveryManager;
 
   
    public void ChangeIconColorDillwynnia()
    {
        
        foreach(SpriteRenderer i in dillwynniaIcons) {i.color = Color.black;}
       
    }
    public void ChangeIconColor7th()
    { foreach (SpriteRenderer i in seventhAve) { i.color = Color.black;  }
    }
    public void ChangeIconColorRueJacques()
    {
        foreach (SpriteRenderer i in rueStJacques) { i.color = Color.black; }
    }
    public void ChangeIconColorNorthWest()
    {
        foreach (SpriteRenderer i in northWest) { i.color = Color.black; }
    }
    public void ChangeIconColorEasternLowlands()
    {
        foreach (SpriteRenderer i in easternLowlands) { i.color = Color.black; }
    }
    public void ResetAllSprites()
    {
        foreach (SpriteRenderer i in seventhAve)
        {
            i.color = Color.white;
        }
        foreach(SpriteRenderer i in dillwynniaIcons)
        {
            i.color = Color.white;
        }
        foreach(SpriteRenderer i in rueStJacques)
        {
            i.color = Color.white;
        }
        foreach (SpriteRenderer i in northWest)
        {
            i.color = Color.white;
        }
        foreach (SpriteRenderer i in easternLowlands)
        {
            i.color = Color.white;
        }
    }
}
