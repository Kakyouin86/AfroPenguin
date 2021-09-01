using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject endScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScreenHeader;
    public TextMeshProUGUI endScreenScoreText;


    // instance
    public static GameUI instance;

    void Awake ()
    {
        instance = this;
    }

    void Start ()
    {
        UpdateScoreText();
    }

    // updates the player's score text
    public void UpdateScoreText ()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    // sets the end screen for a win or game over
    public void SetEndScreen (bool hasWon)
    {
        endScreen.SetActive(true);
        endScreenScoreText.text = "<b>Score</b>\n" + GameManager.instance.score;

        if(hasWon)
        {
            endScreenHeader.text = "You Win";
            endScreenHeader.color = Color.green;
        }
        else
        {
            endScreenHeader.text = "Game Over";
            endScreenHeader.color = Color.red;
        }
    }

    // called when the "Restart" button is pressed
    public void OnRestartButton ()
    {
        GameManager.instance.ResetScore();
        GameManager.instance.TogglePauseGame();
        SceneManager.LoadScene(7);
    }

    // called when the "Menu" button is pressed
    public void OnMenuButton ()
    {
        if(GameManager.instance.paused)
        GameManager.instance.TogglePauseGame();
        SceneManager.LoadScene(0);
    }

    public void OnViewEndingButton()
    {

        GameManager.instance.TogglePauseGame();
        if (GameManager.instance.score > 100)
        {
            SceneManager.LoadScene(4);
            GameManager.instance.ResetScore();
        }
        else if (GameManager.instance.score < 0)
        { 
            SceneManager.LoadScene(6);
            GameManager.instance.ResetScore();
        }
        else
        {
            SceneManager.LoadScene(5);
            GameManager.instance.ResetScore(); 
        }
    }

    // called when the game is paused or un-paused
    public void TogglePauseScreen(bool paused)
    {
        if (endScreen.activeSelf == true)
        { 
            Time.timeScale = 0.0f;
        }
        else
        pauseScreen.SetActive(paused);
    }

    // called when the "Resume" button is pressed
    public void OnResumeButton ()
    {
        GameManager.instance.TogglePauseGame();
    }
}