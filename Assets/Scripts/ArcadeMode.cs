using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;


public class ArcadeMode : MonoBehaviour
{
       
    public int deliveries, score, deliveriesToTrack, scoreToTrack;
    [SerializeField] GameObject[] mailBoxes;

    public bool[] StreetButtonBool = new bool[15]; // creates bools to set which challenge has been chosen
    private bool challengeMailBoxesSpawned = false; // set to true once mailboxes have spawned
    public bool inChallenge = false; // used to check if challenge has begun
    [SerializeField] bool allStreetButtonsFalse = true; // used to check if anyother challenge has already started
    public bool scoreJustAdded; // checks to see if score was just added to stop double delivery
    //getter
    Collision collision;
   [SerializeField] Canvas leaderboardCanvas;

    private void Start()
    {
        collision = FindObjectOfType<Collision>();
    }

    public void CheckForChallenge()
    {
        RunDillwynniaStreet();
        RunJacquesStreet();
        Run7thStreet();
        RunNWStreet();
        RunEastStreet();
    }

    IEnumerator ScoreJustAdded() // stops double delivery
    {
        print("score timer");
        yield return new WaitForSeconds(1);
        scoreJustAdded = false;
    }
    public void GetDeliveriesAmount(int amount) // this is total number of deliveries
    {
        deliveries = amount;
        print("you have this many deliveries" + deliveries);
    }
    public void GetScore(int amount) // this is score per delivery from 0-100
    {
        score = amount;
        CheckForChallenge();
    }  

    public void ScoreFinish()
    {
        
        print("all bools reset");    
     
    }

    private void ScoreOver() // called when final delivery has been made
    {
        allStreetButtonsFalse = true;
        deliveriesToTrack = 0;
       
       
        inChallenge = false;
        print("all bools abotu to reset");
        challengeMailBoxesSpawned= false;

        StartCoroutine(AllStreetButtonsFalse());       

         leaderboardCanvas.enabled = true;

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
        if (allStreetButtonsFalse) {
            StreetButtonBool[index] = true;
            ChallengeButtonClicked();
        }
        
    }

 
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
        if (StreetButtonBool[4] && deliveriesToTrack < 10) { ScoreAdd(); }
        if (deliveriesToTrack >= 5 && StreetButtonBool[4]) { ScoreOver(); }
        EnableJacquesBoxes();
    }
    private void RunJacquesFifteen()
    {
        if (StreetButtonBool[5] && deliveriesToTrack < 15) { ScoreAdd(); }
        if (deliveriesToTrack >= 15 && StreetButtonBool[5]) { ScoreOver(); }
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
   
    private void Run7thStreetFive()
    {
        if (StreetButtonBool[6] && deliveriesToTrack < 5)
        {
            ScoreAdd();

        }
        if (deliveriesToTrack >= 5 && StreetButtonBool[6])
        {
            ScoreOver();

        }      
        Enable7thBoxes();
    }
    
    private void Run7thStreetTen()
    {
        if (StreetButtonBool[7] && deliveriesToTrack < 10)
        {
            ScoreAdd();

        }
        if (deliveriesToTrack >= 10 && StreetButtonBool[7])
        {
            ScoreOver();

        }
        Enable7thBoxes();
    }
    private void Run7thStreetFifteen()
    {
        if (StreetButtonBool[8] && deliveriesToTrack < 15)
        {
            ScoreAdd();

        }
        if (deliveriesToTrack >= 15 && StreetButtonBool[8])
        {
            ScoreOver();

        }
        Enable7thBoxes();
    }
    private void RunNWStreetFive()
    {
        if (StreetButtonBool[9] && deliveriesToTrack < 5)
        {
            ScoreAdd();
        }
        if(deliveriesToTrack >= 5 && StreetButtonBool[9])
        {
            ScoreOver();
        }
        EnableNWBoxes();
    }
    private void RunNWStreetTen()
    {
        if (StreetButtonBool[10] && deliveriesToTrack < 10)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 10 && StreetButtonBool[10])
        {
            ScoreOver();
        }
        EnableNWBoxes();
    }
    private void RunNWStreetFifteen()
    {
        if (StreetButtonBool[11] && deliveriesToTrack < 15)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 15 && StreetButtonBool[11])
        {
            ScoreOver();
        }
        EnableNWBoxes();
    }
    private void RunEastStreetFive()
    {
        if (StreetButtonBool[12] && deliveriesToTrack < 5)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 5 && StreetButtonBool[12])
        {
            ScoreOver();
        }
        EnableEastBoxes();
    }
    private void RunEastStreetTen()
    {
        if (StreetButtonBool[13] && deliveriesToTrack < 10)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 10 && StreetButtonBool[13])
        {
            ScoreOver();
        }
        EnableEastBoxes();
    }
    private void RunEastStreetFifteen()
    {
        if (StreetButtonBool[14] && deliveriesToTrack < 15)
        {
            ScoreAdd();
        }
        if (deliveriesToTrack >= 15 && StreetButtonBool[14])
        {
            ScoreOver();
        }
        EnableEastBoxes();
    }
    private void Enable7thBoxes()
    {
        if (!challengeMailBoxesSpawned && !collision.hasPackage)
        {
            foreach (GameObject mailBox in mailBoxes) // this works
            {
                mailBox.SetActive(false); // to put somewhere better later
                if (mailBox.transform.parent.CompareTag("7thAve"))
                {

                    mailBox.SetActive(true);
                }
                allStreetButtonsFalse = false;
            }
            challengeMailBoxesSpawned = true;
            print("mailboxes 7spawned");
        }
    }
    private void EnableNWBoxes()
    {
        if (!challengeMailBoxesSpawned && !collision.hasPackage )
        {
            foreach (GameObject mailBox in mailBoxes ) // this works
            {
                mailBox.SetActive(false); // to put somewhere better later
                if (mailBox.transform.parent.CompareTag("NorthWest"))
                {

                    mailBox.SetActive(true);
                }
                allStreetButtonsFalse = false;
            }
            challengeMailBoxesSpawned = true;
            print("mailboxes  NW spawned");
        }
    }
    private void EnableEastBoxes()
    {
        if (!challengeMailBoxesSpawned && !collision.hasPackage  )
        {
            foreach (GameObject mailBox in mailBoxes) // this works
            {
                mailBox.SetActive(false); // to put somewhere better later
                if (mailBox.transform.parent.CompareTag("EasternLowlands"))
                {

                    mailBox.SetActive(true);
                }
                allStreetButtonsFalse = false;
            }
            challengeMailBoxesSpawned = true;
            print("mailboxes  EAST spawned");
        }
    }
    private void EnableDillwynniaBoxes()
    {
        if (!challengeMailBoxesSpawned && !collision.hasPackage)
        {
            foreach (GameObject mailBox in mailBoxes)
            {
                mailBox.SetActive(false);
                if (mailBox.transform.parent.CompareTag("Dillwynnia"))
                {
                    mailBox.SetActive(true);
                }
            }
            allStreetButtonsFalse = false;
            challengeMailBoxesSpawned = true;
            print("mailboxes spawned");
        }
    }


    private void EnableJacquesBoxes()
    {
        if (!challengeMailBoxesSpawned && !collision.hasPackage)
        {
            foreach (GameObject mailbox in mailBoxes)
            {
                mailbox.SetActive(false);
                if (mailbox.transform.parent.CompareTag("RueStJacques"))
                {
                    mailbox.SetActive(true);
                }
                allStreetButtonsFalse = false;

            }
            challengeMailBoxesSpawned = true;

        }
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
    private void Run7thStreet()
    {
        Run7thStreetFive();
        Run7thStreetTen();
        Run7thStreetFifteen();
    }
    private void RunNWStreet()
    {
        RunNWStreetFive();
        RunNWStreetTen();
        RunNWStreetFifteen();        
    }
    private void RunEastStreet()
    {
        RunEastStreetFive();
        RunEastStreetTen();
        RunEastStreetFifteen();
    }
    private IEnumerator AllStreetButtonsFalse()
    {
        yield return new WaitForSeconds(3);
        StreetButtonBool[0] = false;
        StreetButtonBool[1] = false;
        StreetButtonBool[2] = false;
        StreetButtonBool[3] = false;
        StreetButtonBool[4] = false;
        StreetButtonBool[5] = false;
        StreetButtonBool[6] = false;
        StreetButtonBool[7] = false;
        StreetButtonBool[8] = false;

        StreetButtonBool[9] = false;
        StreetButtonBool[10] = false;
        StreetButtonBool[11] = false;
        StreetButtonBool[12] = false;
        StreetButtonBool[13] = false;
        StreetButtonBool[14] = false;
        

    }
  
}

