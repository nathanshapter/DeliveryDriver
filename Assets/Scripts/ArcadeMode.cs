using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeMode : MonoBehaviour
{
    /* to create
     * need to track amount of delivers, not in total, but how many after function has begun
     * function that holds all mailboxes to deliver to
     * enabled you to choose records to go against per street, and 5, 10, 15 deliveries
     */

    
    public int deliveries, score, deliveriesToTrack, scoreToTrack;
   public bool[] StreetButtonBool = new bool[15]; // bools as an index
    private bool challengeMailBoxesSpawned = false;
    public bool inChallenge = false;
    [SerializeField] GameObject[] mailBoxes;
    Collision collision;
   [SerializeField] Canvas leaderboardCanvas;

    public bool scoreJustAdded;

    IEnumerator ScoreJustAdded()
    {
        print("score timer");
        yield return new WaitForSeconds(1);
        scoreJustAdded = false;
    }

    private void Start()
    {
        collision = FindObjectOfType<Collision>();    
        
    }
   
    public void CheckForChallenge() 
    {
        RunDillwynniaStreet();
        RunJacquesStreet();
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
   
   
    private void EnableJacquesBoxes()
    {
        if (!challengeMailBoxesSpawned)
        {
            foreach (GameObject mailbox in mailBoxes)
            {
                mailbox.SetActive(false);
                if (mailbox.transform.parent.CompareTag("RueStJacques"))
                {
                    mailbox.SetActive(true);
                }

              //  mailbox.SetActive(true);
            }
            challengeMailBoxesSpawned = true;
            
        }
    }

    public void ScoreFinish()
    {
        // if there is no challenge, add to total score
        print("all bools reset");

     
     //   dillwynniaFiveInProgress = false;
     //   dillwynniaTenInProgress = false;
    //    dillwynniaFifteenInProgress = false;
    }

    private void ScoreOver() // called when final delivery has been made
    {
        
        deliveriesToTrack = 0;
       
       
        inChallenge = false;
        print("all bools abotu to reset");
        challengeMailBoxesSpawned= false;

        FindObjectOfType<ProgressionManager>().IncreaseLevel(); // respawns despawned mailboxes

    }

    public void ScoreAdd()
    {
        if (scoreJustAdded) { return; }
        challengeMailBoxesSpawned = false;
        inChallenge = true;
        if (collision.hasPackage) { deliveriesToTrack++; }       
        print(scoreToTrack);
        scoreToTrack += score;
        print(score);
        print("this is yoru score being tracked" + scoreToTrack);
        print("these are deliveries being tracked" + deliveriesToTrack);
        score = 0;
        scoreJustAdded = true;
        StartCoroutine(ScoreJustAdded());
    }
     
    
    

    private void ChallengeButtonClicked()
    {
        inChallenge = true;
        CheckForChallenge();
        leaderboardCanvas.enabled = false;
    }
    public void StreetButtonsOn(int index)
    {
        StreetButtonBool[index] = true;
        ChallengeButtonClicked();
    }

    //  public bool ReturnCorrectBool { return DillwynniaFiveInProgress = true; }

    //  bool CheckBool(string str)
    //  {

    //  }
    /*
   public void TurnDillwynniaFiveOn()
    {
        dillwynniaFiveInProgress = true;
        ChallengeButtonClicked();
    }

   

    public void TurnDillwynniaTenOn()
    {
        dillwynniaTenInProgress = true;
        ChallengeButtonClicked();
    }
    public void TurnDillwynniaFifteenOn()
    {
        dillwynniaFifteenInProgress = true;
        ChallengeButtonClicked();
    }
    */


    private void RunDillwynniaFive() // to add a timer to this and all others // bools also need to lock delivery destinations
    {

        if (StreetButtonBool[0] && deliveriesToTrack < 5)
        {
            ScoreAdd();

        }
        if (deliveriesToTrack >= 5 && StreetButtonBool[0])
        {
            ScoreOver();

        }
        else
        {
            ;
        }
        EnableDillwynniaBoxes();

    }
    private void RunJacquesFive()
    {
        if (StreetButtonBool[3] && deliveriesToTrack < 5) { ScoreAdd(); }
        if(deliveriesToTrack >= 5 && StreetButtonBool[3]) { ScoreOver(); }
        EnableJacquesBoxes();
    }
    private void RunJacquesTen()
    {
        if (StreetButtonBool[4] && deliveriesToTrack < 5) { ScoreAdd(); }
        if (deliveriesToTrack >= 5 && StreetButtonBool[4]) { ScoreOver(); }
        EnableJacquesBoxes();
    }
    private void RunJacquesFifteen()
    {
        if (StreetButtonBool[5] && deliveriesToTrack < 5) { ScoreAdd(); }
        if (deliveriesToTrack >= 5 && StreetButtonBool[5]) { ScoreOver(); }
        EnableJacquesBoxes();
    }
    private void RunDillwynniaTen()
    {
        if (StreetButtonBool[1] && deliveriesToTrack < 10)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 10 && StreetButtonBool[1])
        {
            ScoreOver();
        }
        else { }
        EnableDillwynniaBoxes();


    }
    private void RunDillwynniaFifteen()
    {
        if (StreetButtonBool[2] && deliveriesToTrack < 15)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 15 && StreetButtonBool[2])
        {
            ScoreOver();
        }
        else { }
        EnableDillwynniaBoxes(); // needs to be added to a button command so that it despawns all other boxes before a delivery is made
    }
    private void RunJacquesStreet() 
    {
        RunJacquesFive();
        RunJacquesTen();
        RunJacquesFifteen();
    }
    private void RunDillwynniaStreet()
    {
        RunDillwynniaFive();
        RunDillwynniaTen();
        RunDillwynniaFifteen();
    }
}
