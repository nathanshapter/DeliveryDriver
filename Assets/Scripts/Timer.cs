using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteDelivery = 30f;
    [SerializeField] Image timerImage;
    [SerializeField] Collision collision;

    public bool isInDelivery = false;
    float timerValue;

    public float fillFraction;

    MoneyManager moneyManager;
    Driver driver;
    MiniMapIcons miniMapIcons;
    PackageSpawn packageSpawn;

    private void Start()
    {
        timerImage.enabled = false;
       moneyManager =  FindObjectOfType<MoneyManager>();
        driver = FindObjectOfType<Driver>();
        miniMapIcons= FindObjectOfType<MiniMapIcons>();
        packageSpawn= FindObjectOfType<PackageSpawn>();
    }
    private void Update()
    {
        UpdateTimer();
        if(!isInDelivery)
        {
            timerImage.enabled = false;
            ResetTimer();
        }
    }
    private void UpdateTimer()
    {        
        timerImage.enabled = true;
        if(timerValue > 0 && isInDelivery)
        {
            timerValue -= Time.deltaTime;
            fillFraction = timerValue/ timeToCompleteDelivery;
            timerImage.fillAmount= fillFraction;
        }       
        
        if (timerValue <= 0 && collision.hasPackage)
        {

            
            isInDelivery = false;
            moneyManager.correctDelivery = false;
            moneyManager.receivedTip= false;
            collision.packageAmount--;
            driver.deliveryText.text = "You ran out of time!";
            moneyManager.addMoney(-10f);
            collision.hasPackage= false;
            packageSpawn.SpawnAPackage();

            miniMapIcons.ResetAllSprites();
            collision.ResetColorOfSprite();
            FindObjectOfType<DeliveryManager>().ResetAllSprites();
            ResetTimer();
        }
    }
    void ResetTimer()
    {
        timerValue = timeToCompleteDelivery;
        fillFraction = 1;
    }
}
