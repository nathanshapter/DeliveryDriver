using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour // handles all collisions, and health
{


    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1); // to be removed when a viable
    [SerializeField] public Color32 hasNoPackageColor = new Color32(1, 1, 1, 1);


    // package stuff
    public bool hasPackage;
    [SerializeField] float destroyDelay;
    SpriteRenderer spriteRenderer;
    [SerializeField] public int packageAmount;

    // moneymanager
    [SerializeField] float flatDelivery = 6.5f, standardPickUp = 5f;
    [SerializeField] float incorrectDelivery = -10f;
    [SerializeField] float carUpgradePrice;
    int repairPrice = 50;

    // car health
    MoneyManager moneyManager;
    [SerializeField] public int originalCarHealth = 100, carHealth = 100;
    int carCollisionDamage;

    // script Gets
    Driver driver;
    [SerializeField] MiniMapIcons miniMapIcons;
    [SerializeField] DeliveryManager deliveryManager;
    [SerializeField] PackageSpawn packageSpawn;
    [SerializeField] Timer timer;
    HUDManager hud;
    ProgressionManager pm;



    private void Start()
    {
        pm = FindObjectOfType<ProgressionManager>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        moneyManager = GetComponent<MoneyManager>();
        driver = GetComponent<Driver>();       
        hud = GetComponent<HUDManager>();      
    }
    private void ProcessGasLeak()
    {
        if (carHealth >= 0)
        {
            driver.gasUsage = driver.gasOriginalUsage;         
        }
        else { driver.gasUsage = driver.gasLeaking; }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        carCollisionDamage = Random.Range(0, 75);
        if(carHealth> 0) { carHealth -= carCollisionDamage; }
        ProcessGasLeak();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" &&!hasPackage)
        {
            ProcessPackageTag(other);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            ProcessCustomerTag(other);
        }

        if (other.tag == "Repair" && moneyManager.wallet >= repairPrice && carHealth <= originalCarHealth)
        {
            moneyManager.wallet -= repairPrice;           
            carHealth = originalCarHealth;
            ProcessGasLeak();
        }
        if(other.tag == "Gas" && moneyManager.wallet >= 0)
        {
            if(driver.gas == driver.fullTank || driver.gas == driver.fullTank/2) { return; }
            driver.gas = driver.fullTank;
            moneyManager.wallet -= moneyManager.gasPrice;            
        }
        if(other.tag == "Upgrade" && moneyManager.wallet >= 1000)
        {
            moneyManager.wallet -= carUpgradePrice;
            originalCarHealth = 500;

        }
        if (other.tag == "Salesman" ) 
        {
            // open menu to buy cars
            hud.deliveryText.text = "Car salesman is not yet open, come back at another time!";

        }

    }

    private void ProcessCustomerTag(Collider2D other)
    {
        moneyManager.correctDelivery = true;
        moneyManager.receivedTip = true;
        other.GetComponent<SpriteRenderer>().color = Color.red;

        packageAmount--;
        hud.deliveryText.text = "Package delivered to" + other;

        if (other.transform != deliveryManager.deliverHere.transform)
        {
            FailedDelivery();
        }
        else
        {
            moneyManager.addMoney(flatDelivery);

            hud.deliveryText.text = "Your delivery to " + deliveryManager.deliverHere.name + " was successful!";
            pm.packagesDelivered++;
            pm.IncreaseLevel();
            timer.isInDelivery = false;

        }
        if (packageAmount == 0)
        {
            ResetColorOfSprite();
            hasPackage = false;
            timer.isInDelivery = false;
        }
        packageSpawn.SpawnAPackage();


        miniMapIcons.ResetAllSprites();
    }

    public void FailedDelivery()
    {
        moneyManager.correctDelivery = false;
        hud.deliveryText.text = "Your delivery to" + deliveryManager.deliverHere.name + " was  NOT successful! ya dumbass";
        moneyManager.receivedTip = false;
        moneyManager.addMoney(incorrectDelivery);
        deliveryManager.deliverHere.GetComponent<SpriteRenderer>().color = Color.red;
        timer.isInDelivery = false;
        hasPackage = false;
        ResetColorOfSprite();
        packageSpawn.SpawnAPackage();
        miniMapIcons.ResetAllSprites();
        
    }

    private void ProcessPackageTag(Collider2D other)
    {
        timer.isInDelivery = true;
        moneyManager.receivedTip = false;
        moneyManager.correctDelivery = true;
        packageAmount++;
        hasPackage = true;
        spriteRenderer.color = hasPackageColor;
        Destroy(other.gameObject, destroyDelay);
        deliveryManager.pickedUp = false;
        deliveryManager.StartDelivery();
        moneyManager.addMoney(standardPickUp);
        hud.deliveryText.text = "Your Delivery to " + deliveryManager.deliverHere.name + " has begun";
    }

    public void ResetColorOfSprite() // returns car to original color
    {
        spriteRenderer.color = hasNoPackageColor;       
    }
}
