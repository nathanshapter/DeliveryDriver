using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Driver : MonoBehaviour
{
    // Handles Gas  

    [SerializeField] public float gas, gasUsage = 1, gasLeaking = 0.1f, gasOriginalUsage; 
    
    public float fullTank = 45f; // gas full tank

    [Range(20f, 100f)] public float cameraSlider = 30f; // use later for player to set size of minimap
    
    MoneyManager moneyManager; // connect to buying more gas


    [SerializeField] Camera miniMapCam;    // zoom in out camera
    [SerializeField] Image gasLiquid;
    
    private void Start()
    {
        
      moneyManager= GetComponent<MoneyManager>();     
    }
    private void Update()
    {
        HandleGas();       
    }
    private void HandleGas()
    {
        if((gas >= 0))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                
                gas -= gasUsage * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                gas -= gasUsage / 10 * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (miniMapCam.orthographicSize != 80)
                {
                    miniMapCam.orthographicSize = 80;
                }
                else
                {
                    miniMapCam.orthographicSize = 45;
                }

            }
            gasLiquid.fillAmount = gas / fullTank;
        }
        else if (Input.GetAxis("Horizontal") >= Mathf.Epsilon || Input.GetAxis("Vertical") >= Mathf.Epsilon)
        {
            //to do add as a UI
            print("you are out of gas! Press 'G' to buy some more! At double the price");

        }
        if(gas <= 0 && Input.GetKeyDown(KeyCode.G))
        {
            gas = fullTank;
            moneyManager.wallet -= moneyManager.gasPrice * 2;
        }
    }
 
}
