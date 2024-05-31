using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitScoreTest : MonoBehaviour
{
    private PlayFabAuthService _AuthService = PlayFabAuthService.Instance;

    public void onSubmitScore()
    {
        _AuthService.SubmitScore(123);
    }
}
