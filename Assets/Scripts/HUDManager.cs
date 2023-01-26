using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI gasText, healthText, walletText, deliveryText, walletInfoText;
    Driver driver;
    Collision collision;
    MoneyManager moneyManager;

    private void Start()
    {
        driver = GetComponent<Driver>();
        collision= GetComponent<Collision>();
        moneyManager = GetComponent<MoneyManager>();
    }
    private void Update()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        gasText.text = "You have " + driver.gas + "L of gas ";
        healthText.text = "Car Health: " + collision.carHealth;
        walletText.text = "Money: " + moneyManager.wallet;
    }
}
