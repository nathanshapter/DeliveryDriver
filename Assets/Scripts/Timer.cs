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
    public float timerValue, timerOriginalValue, timerTotalValue;
    public bool isInDelivery = false;
   

    bool timerSet;

    //getter
  
    HUDManager hud;
    [SerializeField] Collision collision;

    public float dillwynniaTimer, seventhTimer, jacquesTimer, nwTimer, EasternTimer;
 

    private void Start()
    {
        timerImage.enabled = false;
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
            if(!timerSet) { timerTotalValue= timerValue; timerSet = true; }
            
            timerValue -= Time.deltaTime;
            fillFraction = timerValue/ timerTotalValue;
            timerImage.fillAmount= fillFraction;
        }
        
        if (timerValue <= 0 && collision.hasPackage)
        {
            collision.FailedDelivery();
            
            isInDelivery = false;
            
            collision.packageAmount--;
            hud.deliveryText.text = "You ran out of time!";          
             ResetTimer();
        }
    }
    void ResetTimer()
    {
        
        fillFraction = 1;
        timerValue = timerOriginalValue;
        timerTotalValue = timerValue;
        timerSet= false;
    }
    
}
