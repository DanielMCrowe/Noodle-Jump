using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services;
using UnityEngine;

public class InitializeUGS : MonoBehaviour
{
    async void Start() {
        Debug.Log("its there");
        try {
            await InitializeServices();
        } catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    async Task InitializeServices()
    {
      
        await UnityServices.InitializeAsync();

        if (this == null) return;

        Debug.Log("Services Initialized.");

        if(!AuthenticationService.Instance.IsSignedIn)
        {
            Debug.Log("Signing in...");
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            if(this== null) return;
        }

        Debug.Log($"Player id: {AuthenticationService.Instance.PlayerId}");
        
        
    } 
}
