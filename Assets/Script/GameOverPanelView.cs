using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelView : MonoBehaviour
{
    public Button mainMenuButton;
    public Button restartButton;
    public GameObject mainCamera;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        mainMenuButton.onClick.AddListener(goToMainMenu);
        restartButton.onClick.AddListener(resetScene);
    }

    public void Update()
    {
        string cameraYPositionString = (mainCamera.transform.position.y - 0.1f).ToString("F1");
        cameraYPositionString = cameraYPositionString.Replace(".", "");
        scoreText.text = "" + cameraYPositionString + " Points";
    }

    private void goToMainMenu() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    
    }

    private void resetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        


    }
}
