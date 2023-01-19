using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Driver : MonoBehaviour
{
    [SerializeField] public float steerSpeed = 225f, moveSpeed = 25f, originalSpeed = 25f;
    [SerializeField] public float slowSpeed, boostSpeed;
    [SerializeField] public float gas, gasUsage = 10;
    public float fullTank = 45f;
    [SerializeField] public TextMeshProUGUI gasText, healthText, walletText, deliveryText, walletInfoText;

    Collision collision;
    MoneyManager moneyManager;

    [SerializeField] Camera miniMapCam;

    

  

 
   
    private void Start()
    {
       collision= GetComponent<Collision>();
        moneyManager= GetComponent<MoneyManager>();
       
    }
    private void Update()
    {

        Drive();      
        UpdateText();
    }

    private void UpdateText()
    {
        gasText.text = "You have " + gas + "L of gas ";
        healthText.text = "Car Health: " + collision.carHealth;
        walletText.text = "You have  " + moneyManager.wallet + "  DollaryDoos";
    }

    private void Drive()
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
                if (miniMapCam.orthographicSize != 60)
                {
                    miniMapCam.orthographicSize = 60;
                }
                else
                {
                    miniMapCam.orthographicSize = 20;
                }

            }
        //   if (Input.GetKeyDown(KeyCode.LeftShift)) { steerSpeed = steerSpeed * 2; }
         //   if (Input.GetKeyUp(KeyCode.LeftShift)) { steerSpeed = steerSpeed/ 2; }
        //   if (Input.GetKeyDown(KeyCode.Space) && moveSpeed == originalSpeed) { moveSpeed = moveSpeed / 2; }
        //   if (Input.GetKeyUp(KeyCode.Space) && moveSpeed <= originalSpeed && moveSpeed != slowSpeed) { moveSpeed = originalSpeed; }
         //   float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //   float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //    transform.Rotate(0, 0, -steerAmount);
        //   transform.Translate(0, moveAmount, 0);          
           
           
            
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
