using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI playerNames, playerScores;
    int dillwynniaFiveLeaderBoardID = 10799, dillwynniaTenLeaderBoardID = 10841, dillwynniaFifteenLeaderboardID = 10852, allTimeLeaderBoardID = 10842, jacquesFiveLeaderBoardID = 10970, jacquesTenLeaderBoardID = 10971, jacquesFifteenLeaderBoardID = 10972, seventhFiveLeaderBoardID = 10984, seventhTenLeaderBoardID = 10985, SeventhFifteenLeaderBoardID = 10986, nwFiveLeaderBoardID = 10987, nwTenLeaderBoardID = 10988, nwFifteenLeaderBoardID = 10989, eastFiveLeaderBoardID = 10990, eastTenLeaderBoardID = 10991, eastFifteenLeaderBoardID = 10992;  
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
        LootLockerSDKManager.GetScoreListMain(jacquesFiveLeaderBoardID, 10, 0, (response) =>
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
    { // these are being set to false before the last delviery is counted
        if (am.StreetButtonBool[0] == true) { return dillwynniaFiveLeaderBoardID; }
        else if(am.StreetButtonBool[1] == true) { return dillwynniaTenLeaderBoardID; }
        else if(am.StreetButtonBool[2] == true) { return dillwynniaFifteenLeaderboardID; }
        else if (am.StreetButtonBool[3] == true) { return jacquesFiveLeaderBoardID; }
        else if (am.StreetButtonBool[4] == true) { return jacquesTenLeaderBoardID; }
        else if (am.StreetButtonBool[5] == true) { return jacquesFifteenLeaderBoardID; }
        else if (am.StreetButtonBool[6] == true) { return seventhFiveLeaderBoardID; }
        else if (am.StreetButtonBool[7] == true) { return seventhTenLeaderBoardID; }
        else if (am.StreetButtonBool[8] == true) { return SeventhFifteenLeaderBoardID; }
        else if (am.StreetButtonBool[9] == true) { return nwFiveLeaderBoardID; }
        else if (am.StreetButtonBool[10] == true) { return nwTenLeaderBoardID; }
        else if (am.StreetButtonBool[11] == true) { return nwFifteenLeaderBoardID; }
        else if (am.StreetButtonBool[12] == true) { return eastFiveLeaderBoardID; }
        else if (am.StreetButtonBool[13] == true) { return eastTenLeaderBoardID; }
        else if (am.StreetButtonBool[14] == true) { return eastFifteenLeaderBoardID; }
        else { return allTimeLeaderBoardID ; }
    }
}
