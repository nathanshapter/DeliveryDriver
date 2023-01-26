using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public bool readyForDelivery = false;
    [SerializeField] GameObject[] deliveryPlace;
    int index;
    public GameObject deliverHere;
    public bool pickedUp = false;
   [SerializeField] Sprite square, circle;
   [SerializeField] MiniMapIcons miniMapIcons;

   [SerializeField] Collision collision;

    [SerializeField] float dillwynniaPrime, seventhAvePrime, jacquesPrime, nWPrime, easternPrime;
    [SerializeField] MoneyManager moneyManager;

   [SerializeField] Timer timer;

  
    public void StartDelivery()
    {
        if (collision.hasPackage != true || pickedUp != false)
        {
            return;
            
        }
        DeliveryReady();
        pickedUp = true;
    }

    public void DeliveryReady()
    {
        
        deliveryPlace = GameObject.FindGameObjectsWithTag("Customer");
        index = Random.Range(0, deliveryPlace.Length);
        deliverHere = deliveryPlace[index];
        print(deliverHere.name);

        deliverHere.GetComponent<SpriteRenderer>().color = Color.white;

        print("delivery begun");
      
      if(deliverHere.transform.parent.CompareTag("Dillwynnia"))
        {
            miniMapIcons.ChangeIconColorDillwynnia();
            moneyManager.addMoney(dillwynniaPrime);
            collision.tempMoney += dillwynniaPrime;
            timer.timerValue += timer.dillwynniaTimer;
            
        }
      if (deliverHere.transform.parent.CompareTag("7thAve"))
        {            
            miniMapIcons.ChangeIconColor7th();
            moneyManager.addMoney(seventhAvePrime);
            collision.tempMoney += seventhAvePrime;
            timer.timerValue += timer.seventhTimer;
            
        }
        if (deliverHere.transform.parent.CompareTag("RueStJacques"))
        {
            miniMapIcons.ChangeIconColorRueJacques();
            moneyManager.addMoney(jacquesPrime);
            collision.tempMoney += jacquesPrime;
            timer.timerValue += timer.jacquesTimer;
        }
        if (deliverHere.transform.parent.CompareTag("NorthWest"))
        {
            miniMapIcons.ChangeIconColorNorthWest();
            moneyManager.addMoney(nWPrime);
            collision.tempMoney += nWPrime;
            timer.timerValue += timer.nwTimer;

        }
        if (deliverHere.transform.parent.CompareTag("EasternLowlands"))
        {
            miniMapIcons.ChangeIconColorEasternLowlands();
            moneyManager.addMoney(easternPrime);
            collision.tempMoney += easternPrime;
            timer.timerValue += timer.EasternTimer;
        }

    }
    public void ResetAllSprites()
    {
        foreach(GameObject i in deliveryPlace)
        {
            i.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
   

   
}
