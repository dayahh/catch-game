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

    private float level2Req = 10f; //the time you need to last to reach level 2

    private Boolean passedLVL1 = false;

    public GameObject nextLevelButton;


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

        StartCoroutine(LevelUnlocked());

    }

    IEnumerator LevelUnlocked()
    {
        yield return new WaitForSeconds(level2Req);

        // now do something
        // Debug.Log("tracking time...");
        passedLVL1 = true;

        if(passedLVL1 == true){
            nextLevelButton.gameObject.SetActive(true);
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

    public void GoToNextLevel()
    {
        SceneManager.GetSceneByName("Level2");
    }


}
