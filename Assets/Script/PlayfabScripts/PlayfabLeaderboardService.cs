using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class PlayfabLeaderboardService : MonoBehaviour
{

    public static PlayfabLeaderboardService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayfabLeaderboardService();
            }
            return _instance;
        }
    }

    private static PlayfabLeaderboardService _instance;

    public PlayfabLeaderboardService()
    {
        _instance = this;
    }
    public void SubmitScore(int playerScore)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
            new StatisticUpdate {
                StatisticName = "HighScore",
                Value = playerScore
            }
        }
        }, result => OnStatisticsUpdated(result), FailureCallback);
    }
    public void RequestLeaderboard(Action<GetLeaderboardResult> resultCallback)
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 6
        }, resultCallback, FailureCallback);
    }

    

    private void OnStatisticsUpdated(UpdatePlayerStatisticsResult updateResult)
    {
        Debug.Log("Successfully submitted high score");
    }

    private void FailureCallback(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}