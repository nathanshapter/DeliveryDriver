using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI playerNames, playerScores;
    int dillwynniaFiveLeaderBoardID = 10799, dillwynniaTenLeaderBoardID = 10841, allTimeLeaderBoardID = 10842;
    [SerializeField] ArcadeMode am;
  public   IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
#pragma warning disable CS0618 // Type or member is obsolete
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload,ReturnLeaderBoardID(),(response) => {
            if (response.success)
            {
                Debug.Log("uploaded score to leaderboard");
                done= true;
            }
            else { Debug.Log("no bueno" + response.Error);
                done = true;
            }
        });
#pragma warning restore CS0618 // Type or member is obsolete
        yield return new WaitWhile(() => done == false);
    }

    [System.Obsolete]
    public IEnumerator FetchTopHighScoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(dillwynniaFiveLeaderBoardID, 10, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else { Debug.Log(" failed" + response.Error); 
            done = true;}
        });
        yield return new WaitWhile(()=> done == false);
    }
    public int ReturnLeaderBoardID() // needs to eventually root into all leaderboard ID's and all true/false statements
    {
        if(am.dillwynniaFiveInProgress == true) { return dillwynniaFiveLeaderBoardID; }
        if(am.dillwynniaTenInProgress == true) { return dillwynniaTenLeaderBoardID; }
        else { return allTimeLeaderBoardID; }
    }
}
