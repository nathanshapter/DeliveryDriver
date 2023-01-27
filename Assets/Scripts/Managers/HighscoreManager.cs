using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public Leaderboard leaderboard;
    public TMP_InputField playerNameInputField;
    [SerializeField] GameObject leaderboardCanvas;

    private void Start()
    {
        StartCoroutine(SetupRoutine());
    }
    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) =>
        {
            if (response.success)
            {
                
                Debug.Log(" set player name");
            }
            else { Debug.Log(" playername fail" + response.Error); }
        });
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            if (leaderboardCanvas)
            {
                leaderboardCanvas.SetActive(false);

            }
            if (!leaderboardCanvas) { leaderboardCanvas.SetActive(true); }

        }
    }

    [System.Obsolete]
    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighScoresRoutine();
    }
    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("itworked!");
                PlayerPrefs.SetString("Player ID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("rip");
                done = true;
            }
        }
        );
        yield return new WaitWhile(() =>done == false);
    }
}
