using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public GetPlayerCombinedInfoRequestParams InfoRequestParams;

    private PlayFabAuthService _AuthService = PlayFabAuthService.Instance;
    private PlayfabLeaderboardService _LeaderboardService = PlayfabLeaderboardService.Instance;

    public Button playButton;
    public Button exitButton;
    public Button exitGameButton;
    public Button youStinkExitButton;
    public Button leaderboardButton;

    public GameObject leaderboardPanel;
    public GameObject youStinkLeaderboardPanel;

    public GameObject leaderboardEntries;
    public GameObject leaderboardEntry;

    private void Start()
    {

        leaderboardPanel.SetActive(false);
        PlayFabAuthService.OnDisplayAuthentication += OnDisplayAuthentication;
        PlayFabAuthService.OnLoginSuccess += OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError += OnPlayFaberror;
        _AuthService.InfoRequestParams = InfoRequestParams;
        _AuthService.Authenticate();
        exitButton.onClick.AddListener(onExitButtonClicked);
        youStinkExitButton.onClick.AddListener(onYouStinkExitButtonClicked);
        playButton.onClick.AddListener(onPlayClicked);
        leaderboardButton.onClick.AddListener(getLeaderboard);
        exitGameButton.onClick.AddListener(onExitGame);

        
    }

    private void onExitGame()
    {
        Application.Quit();
    }
    private void onYouStinkExitButtonClicked()
    {
       youStinkLeaderboardPanel.SetActive(false);
    }

    private void onExitButtonClicked()
    {
        leaderboardPanel.SetActive(false);
        foreach (Transform child in leaderboardEntries.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void getLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        Action<GetLeaderboardResult> displayLeaderboard = DisplayLeaderboard;
       _LeaderboardService.RequestLeaderboard(displayLeaderboard);
    }
    private void DisplayLeaderboard(GetLeaderboardResult result)
    {
            List<PlayerLeaderboardEntry> leaderboard = result.Leaderboard;
            for (int i = leaderboard.Count - 1; i >= 0; i--)
            {
                GameObject leaderboardEntryGameobject = Instantiate(leaderboardEntry, leaderboardEntries.gameObject.transform);
                leaderboardEntryGameobject.GetComponent<LeaderboardEntry>().setValues(leaderboard[i]);
            }
        
    }

    private void onPlayClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    private void OnLoginSuccess(PlayFab.ClientModels.LoginResult result)
    {
        Debug.Log(result.InfoResultPayload.TitleData);
        
    }
    private void OnPlayFaberror(PlayFabError error)
    {
        Debug.Log(error.Error);
        Debug.LogError(error.GenerateErrorReport());
    }
    private void OnDisplayAuthentication()
    {
        Debug.Log("singing in the shower...");
        _AuthService.Authenticate(Authtypes.Silent);
    }
}
