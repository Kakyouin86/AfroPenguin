using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool paused;

    // instance
    public static GameManager instance;

    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
                TogglePauseGame();
        }
    }

    // pauses or unpauses the game
    public void TogglePauseGame ()
    {
        paused = !paused;

        if (paused)
        {
            FindObjectOfType<MusicControl>().PauseCode();
            Time.timeScale = 0.0f;
        }
        else
        {
            FindObjectOfType<MusicControl>().UnPauseCode();
            Time.timeScale = 1.0f;
        }

        GameUI.instance.TogglePauseScreen(paused);
    }

    // adds to the player's score
    public void AddScore (int scoreToGive)
    {
        score += scoreToGive;
        GameUI.instance.UpdateScoreText();
    }

    public void ResetScore ()
    {
        score = 0;
        GameUI.instance.UpdateScoreText();
    }

    // called when the player enters a goal
    public void LevelEnd ()
    {
        // is this the last level?
        if(SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            WinGame();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // called when the player wins the game
    public void WinGame ()
    {
        FindObjectOfType<MusicControl>().YouWinMusicCode();
        GameUI.instance.SetEndScreen(true);
        Time.timeScale = 0.0f;
    }

    // called when the player hits an enemy
    public void GameOver ()
    {
        //audioSource.Pause();
        //Destroy(backgroundMusicLevel1);
        FindObjectOfType<MusicControl>().GameOverMusicCode();
        GameUI.instance.SetEndScreen(false);
        Time.timeScale = 0.0f;
        //audioSource.PlayOneShot(GameOverSound, 0.4F);

    }
}