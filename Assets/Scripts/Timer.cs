using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //timer UI
    [SerializeField] Image timerImage;

    //timer logic
    public float fillFraction;
    float timerValue;
    public bool isInDelivery = false;
    [SerializeField] float timeToCompleteDelivery = 30f;

    //getter
    MiniMapIcons miniMapIcons;
    PackageSpawn packageSpawn;
    HUDManager hud;
    [SerializeField] Collision collision;
    MoneyManager moneyManager;

    private void Start()
    {
        timerImage.enabled = false;
       moneyManager =  FindObjectOfType<MoneyManager>();
       
        miniMapIcons= FindObjectOfType<MiniMapIcons>();
        packageSpawn= FindObjectOfType<PackageSpawn>();
        hud = FindObjectOfType<HUDManager>();
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
            collision.FailedDelivery();
            
            isInDelivery = false;
            
            collision.packageAmount--;
            hud.deliveryText.text = "You ran out of time!";
            
            
            
            
         
         //   FindObjectOfType<DeliveryManager>().ResetAllSprites();
            ResetTimer();
        }
    }
    void ResetTimer()
    {
        timerValue = timeToCompleteDelivery;
        fillFraction = 1;
    }
}
