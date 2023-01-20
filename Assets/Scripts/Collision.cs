using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool hasPackage;
    [SerializeField] float destroyDelay;

    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] public Color32 hasNoPackageColor = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;
    [SerializeField] Driver driver;

    MoneyManager moneyManager;
    [SerializeField] public int packageAmount;

    int boostPrice = 200, repairPrice = 50;
    
    [SerializeField] float Dillwynnia = 6.5f, standardPickUp = 5f;
    [SerializeField] int originalCarHealth = 100;
    [SerializeField] public int carHealth = 100;
    int carCollisionDamage;

    [SerializeField] float incorrectDelivery = -10f;
    [SerializeField] MiniMapIcons miniMapIcons;

    [SerializeField] float carUpgradePrice;

    [SerializeField] DeliveryManager deliveryManager;
    [SerializeField] PackageSpawn packageSpawn;

    [SerializeField] Timer timer;

    TopDownCarController topDownCarController;

    HUDManager hud;
    private void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        moneyManager = GetComponent<MoneyManager>();
        driver = GetComponent<Driver>();
        topDownCarController = GetComponent<TopDownCarController>();
        hud = GetComponent<HUDManager>();
      
    }
    private void Update()
    {
        if (carHealth <= 0)
        {
            driver.gasUsage = 1f;
        }
        else { driver.gasUsage = 0.1f; }
     
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        carCollisionDamage = Random.Range(0, 75);
        print(this.gameObject);
        print(other.gameObject);
        if(carHealth> 0) { carHealth -= carCollisionDamage; print(carHealth); }
       
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" &&!hasPackage)
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
       
        if (other.tag == "Customer" && hasPackage)
        {
            moneyManager.correctDelivery = true;
            moneyManager.receivedTip = true;
            other.GetComponent<SpriteRenderer>().color = Color.red;
            
            packageAmount--;
            hud.deliveryText.text = "Package delivered to" + other;
            
            if(other.transform != deliveryManager.deliverHere.transform)
            {
                moneyManager.correctDelivery = false;
                hud.deliveryText.text = "Your delivery to" + deliveryManager.deliverHere.name + " was  NOT successful! ya dumbass";
                moneyManager.addMoney(incorrectDelivery);
                deliveryManager.deliverHere.GetComponent<SpriteRenderer>().color = Color.red;
                timer.isInDelivery = false;
            }
            else
            {
                moneyManager.addMoney(Dillwynnia);
               
                hud.deliveryText.text = "Your delivery to " + deliveryManager.deliverHere.name + " was successful!";
                timer.isInDelivery = false;

            }
            if(packageAmount == 0)
            {
                ResetColorOfSprite();
                hasPackage = false;
                timer.isInDelivery = false;
            }
            packageSpawn.SpawnAPackage();
          

            miniMapIcons.ResetAllSprites();
        }
      
        if(other.tag == "Repair" && moneyManager.wallet >= repairPrice && carHealth <= originalCarHealth)
        {
            moneyManager.wallet -= repairPrice;
           
            carHealth = originalCarHealth;
        

        }
        if(other.tag == "Gas" && moneyManager.wallet >= 0)
        {
            if(driver.gas == driver.fullTank ) { return; }
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
            print("sales man is not yet available!");
            hud.deliveryText.text = "Car salesman is not yet open, come back at another time!";

        }

    }
    public void ResetColorOfSprite()
    {
        spriteRenderer.color = hasNoPackageColor;
       
    }
}
