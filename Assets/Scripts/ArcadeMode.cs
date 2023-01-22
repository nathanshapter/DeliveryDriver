using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMode : MonoBehaviour
{
    /* to create
     * need to track amount of delivers, not in total, but how many after function has begun
     * function that holds all mailboxes to deliver to
     * enabled you to choose records to go against per street, and 5, 10, 15 deliveries
     */

    Collision collision;
    public int deliveries, score, deliveriesToTrack, scoreToTrack;
   public bool DillwynniaFiveInProgress = false;

    private void Start()
    {
        collision= FindObjectOfType<Collision>();
        
    }
   
    public void CheckForChallenge()
    {
        RunDillwynniaFive();
    }

    public void GetDeliveriesAmount(int amount) // this is total number of deliveries
    {
        
        deliveries = amount;
          print("you have this many deliveries" + deliveries);
        CheckForChallenge();
        
    }
    public void GetScore(int amount) // this is score per delivery from 0-100
    {
       
        score = amount;
        
    }    
  private void RunDillwynniaFive() // to add a timer to this and all others
    {
        if(DillwynniaFiveInProgress)
        {
            deliveriesToTrack++;
            scoreToTrack += score;
            print(scoreToTrack);
            print("this is yoru score being tracked" + scoreToTrack);
            print("these are deliveries being tracked" + deliveriesToTrack);
        }
        if(deliveries >= 5)
        {
            
            deliveriesToTrack = 0;
            scoreToTrack = 0; score = 0;
            DillwynniaFiveInProgress=false;
            print(DillwynniaFiveInProgress);

        }
        else
        {
            scoreToTrack += score;
            print("else working");
        }
    }
 // figure out how this works lol   public bool ReturnCorrectBool { return DillwynniaFiveInProgress = true; }
}
