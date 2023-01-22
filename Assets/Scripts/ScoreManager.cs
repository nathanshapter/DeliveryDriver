using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public bool arcadeMode = false;
    [SerializeField] Leaderboard leaderboard;
    [SerializeField] public int scoreAddition, score;


    ArcadeMode am;

    private void Start()
    {
        am = FindObjectOfType<ArcadeMode>();
    }
    public void GetNumber(int number)
    {
        scoreAddition = number;
        score += scoreAddition;
        StartCoroutine(addToScore());
    }
    
    IEnumerator addToScore()
    {
        yield return new WaitForSeconds(3); // this is so am.scoreToTrack has correct amount of time to calculate before being sent to the server
        yield return leaderboard.SubmitScoreRoutine(am.scoreToTrack); 
    }
}
