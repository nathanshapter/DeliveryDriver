using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyManager : MonoBehaviour
{
    [SerializeField] public float flatDeliveryRate, wallet, gasPrice = 20;
    public bool receivedTip;
    public bool correctDelivery = true;
    public float deliveryFail = 20;

    //to remove just for following

    public Leaderboard leaderboard;

    ArcadeMode am;
   

    HUDManager hud;
    private void Start()
    {        
        am = FindObjectOfType<ArcadeMode>();
        hud = GetComponent<HUDManager>();
    }

    public void addMoney(float amount)
    {
        if(am.allStreetButtonsFalse)
        {
            wallet += amount;
            float tipAmount = Random.Range(amount / 100, amount * 1.5f);
            if (receivedTip) { wallet += tipAmount; }


            if (receivedTip && correctDelivery)
            {
                hud.walletInfoText.text = "You received " + amount + "for the delivery and " + tipAmount + "for the tip";
            }
            else if (!correctDelivery)
            {
                hud.walletInfoText.text = "You had this amount " + (amount + tipAmount) + " taken from you. And were fined " + deliveryFail;
                wallet -= (amount + tipAmount + deliveryFail);
                deliveryFail *= 1.1f;
            }
            else
            {
                hud.walletInfoText.text = "You received " + amount + "for picking up the delivery";
            }
        }
       
       // float newFloat = System.Convert.ToInt32(scoreManager.scoreAddition);
       // wallet+= newFloat;
    }
    
}
