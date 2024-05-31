using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab.ClientModels;

public class LeaderboardEntry : MonoBehaviour
{
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI displayNameText;
    public TextMeshProUGUI playFabIdText;
    public TextMeshProUGUI StatValueText;

    public void setValues(PlayerLeaderboardEntry entry)
    {
        positionText.text = "" + entry.Position; 
        displayNameText.text = entry.DisplayName;
        playFabIdText.text = entry.PlayFabId;
        StatValueText.text = "" + entry.StatValue;
    }
}
