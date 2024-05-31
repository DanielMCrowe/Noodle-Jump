using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Data;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    
    public void Update()
    {
        moveCamera();
    }
    public void moveCamera()
    {
        if (player != null)
            if (player.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            }

    }
}
