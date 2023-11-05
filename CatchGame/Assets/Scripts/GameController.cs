using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public Canvas GameOverCanvas;
    public TMP_Text TimerText;

    private void Awake() 
    {
        if(playerController != null)
        {
            playerController.PlayerDied += WhenPlayerDies;
        }

        if(GameOverCanvas.gameObject.activeSelf)
        {
            GameOverCanvas.gameObject.SetActive(false);
        }
    }

    void WhenPlayerDies()
    {

        GameOverCanvas.gameObject.SetActive(true);
        TimerText.text = "You lasted: " + Math.Round(Time.timeSinceLevelLoad, 2) + " seconds!";

        if(playerController != null)
        {
            playerController.PlayerDied -= WhenPlayerDies;
        }
    }

    public void RetryClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
