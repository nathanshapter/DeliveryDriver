using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] public float flatRate, wallet, gasPrice = 20;
    public bool receivedTip;
    public bool correctDelivery = true;
    public float deliveryFail = 20;

    Driver driver;
    private void Start()
    {
        driver= GetComponent<Driver>();
    }

    public void addMoney(float amount)
    {
        wallet += amount;
        float tipAmount = Random.Range(amount / 100, amount * 1.5f);
        if (receivedTip) { wallet += tipAmount; }
        
        


        if (receivedTip && correctDelivery)
        {
            driver.walletInfoText.text = "You received " + amount + "for the delivery and " + tipAmount + "for the tip";
        }
        else if (!correctDelivery)
        {
            driver.walletInfoText.text = "You had this amount " + (amount + tipAmount) + " taken from you. And were fined " + deliveryFail;
            wallet -= (amount + tipAmount + deliveryFail);
            deliveryFail *= 1.1f;
        }
        else
        {
            driver.walletInfoText.text = "You received " + amount + "for picking up the delivery";
        }
       

        
    }
}
