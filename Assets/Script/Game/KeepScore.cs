using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepScore : MonoBehaviour
{
    public Transform player;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject mainCamera;
    public float highestScore = 0;

    public void Update()
    {
        keepScore();
    }
    public void keepScore()
    {
        float camY = mainCamera.transform.position.y;
        if (camY > highestScore)
        {
            score = (int) (camY * 10);
            scoreText.text = "Score: " + score.ToString();
            highestScore = camY;
        }
    }
}
