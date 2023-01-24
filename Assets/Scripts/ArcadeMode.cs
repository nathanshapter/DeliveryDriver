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

    
    public int deliveries, score, deliveriesToTrack, scoreToTrack;
   public bool dillwynniaFiveInProgress = false, dillwynniaTenInProgress = false, dillwynniaFifteenInProgress; // bools for every street + 3 modes
    private bool challengeMailBoxesSpawned = false;
    public bool inChallenge = false;
    [SerializeField] GameObject[] mailBoxes;

    private void Start()
    {      
        dillwynniaFiveInProgress = true; // temp set       
        inChallenge = true;
        
    }
   
    public void CheckForChallenge() // this needs to be enabled via buttons to start them if the bool is true
    {
        RunDillwynniaFive();
        RunDillwynniaTen();
        RunDillwynniaFifteen();
        
    }
    private void RunDillwynniaFifteen()
    {
        if(dillwynniaFifteenInProgress && deliveriesToTrack < 15)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 15 && dillwynniaFifteenInProgress)
        {
            ScoreOver();
        }
        else { }
        EnableDillwynniaBoxes(); // needs to be added to a button command so that it despawns all other boxes before a delivery is made
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
  private void RunDillwynniaFive() // to add a timer to this and all others // bools also need to lock delivery destinations
    {
       
        if (dillwynniaFiveInProgress && deliveriesToTrack < 5)
        {
            ScoreAdd();
            
        }
        if (deliveriesToTrack >= 5 && dillwynniaFiveInProgress)
        {
            ScoreOver();

        }
        else
        {
            ;
        }
        EnableDillwynniaBoxes();
        
    }

    private void EnableDillwynniaBoxes()
    {
        if (!challengeMailBoxesSpawned)
        {
            foreach (GameObject mailBox in mailBoxes) // this works
            {
                mailBox.SetActive(false); // to put somewhere better later
                if (mailBox.transform.parent.CompareTag("Dillwynnia"))
                {

                    mailBox.SetActive(true);
                }
            }
            challengeMailBoxesSpawned = true;
            print("mailboxes spawned");
        }
    }

    public void ScoreFinish()
    {
        // if there is no challenge, add to toal score
        dillwynniaFiveInProgress = false;
        dillwynniaTenInProgress = false;
        dillwynniaFifteenInProgress = false;
    }

    private void ScoreOver()
    {
        
        deliveriesToTrack = 0;
       
       
        inChallenge = false;
        print("all bools abotu to reset");
        challengeMailBoxesSpawned= false;

    }

    public void ScoreAdd()
    {
        challengeMailBoxesSpawned = false;
        inChallenge = true;
        deliveriesToTrack++;
        print(scoreToTrack);
        scoreToTrack += score;
        print(score);
        print("this is yoru score being tracked" + scoreToTrack);
        print("these are deliveries being tracked" + deliveriesToTrack);
        score = 0;
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
        else {}
        EnableDillwynniaBoxes();


    }



//  public bool ReturnCorrectBool { return DillwynniaFiveInProgress = true; }

 //  bool CheckBool(string str)
  //  {

  //  }
}
