using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject player;
    public GameObject mainCamera;

    enum GameState
    {
        Home,
        Leaderboard,
        Settings,
        Play,
        End
    }
    GameState state = GameState.Play;

    private PlayfabLeaderboardService _LeaderboardService = PlayfabLeaderboardService.Instance;

    public void Update()
    {
        if (state == GameState.Play)
        {
            killPlayer();
        }
    }

    public void killPlayer()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if (player.transform.position.y < stageDimensions.y)
        {
            Destroy(player);
            Debug.Log("youre dead smelly");
            state = GameState.End;
            _LeaderboardService.SubmitScore((int)(mainCamera.transform.position.y * 10));
            gameOverPanel.SetActive(true);
        }
    }

    
}
