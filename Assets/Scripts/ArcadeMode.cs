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
   public bool dillwynniaFiveInProgress = false, dillwynniaTenInProgress = false;

    private void Start()
    {
        collision= FindObjectOfType<Collision>();
        dillwynniaTenInProgress = true;
    }
   
    public void CheckForChallenge()
    {
        RunDillwynniaFive();
        RunDillwynniaTen();
    }

    public void GetDeliveriesAmount(int amount) // this is total number of deliveries
    {
        
        deliveries = amount;
          print("you have this many deliveries" + deliveries);
        
        
    }
    public void GetScore(int amount) // this is score per delivery from 0-100
    {
        print(amount);
        
        score = amount;
        print(score);
        CheckForChallenge();
    }    
  private void RunDillwynniaFive() // to add a timer to this and all others
    {
        if(dillwynniaFiveInProgress && deliveriesToTrack < 5)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 5 && dillwynniaFiveInProgress)
        {
            ScoreOver();

        }
        else
        {
            ScoreFinish();
        }
    }

    private void ScoreFinish()
    {
       // if there is no challenge, add to toal score
        
    }

    private void ScoreOver()
    {
        deliveriesToTrack = 0;
        scoreToTrack = 0; score = 0;
        dillwynniaFiveInProgress = false;
        dillwynniaTenInProgress = false;
        print("all bools reset");
    }

    private void ScoreAdd()
    {
        deliveriesToTrack++;
        print(scoreToTrack);
        scoreToTrack += score;
        print(score);
        print("this is yoru score being tracked" + scoreToTrack);
        print("these are deliveries being tracked" + deliveriesToTrack);
    }

    private void RunDillwynniaTen()
    {
        if (dillwynniaTenInProgress && deliveriesToTrack < 10)
        {
            ScoreAdd();
        }
        if(deliveriesToTrack >= 10 && dillwynniaTenInProgress)
        {
            ScoreOver();
        }
        else {ScoreFinish();}

    }
//  public bool ReturnCorrectBool { return DillwynniaFiveInProgress = true; }

 //  bool CheckBool(string str)
  //  {

  //  }
}
