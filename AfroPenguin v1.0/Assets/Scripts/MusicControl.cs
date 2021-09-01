using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{
    public AudioSource YouWinMusic;
    public AudioSource GameOverMusic;
    public AudioSource backgroundMusicLevel1;

    public bool backgroundSongLevel1 = true;
    public bool GameOverSong = false;
    public bool YouWinSong = false;

    public void MusicLevel1()
    {
        backgroundSongLevel1 = true;
        YouWinSong = false;
        GameOverSong = false;
        backgroundMusicLevel1.Play();
    }



    public void YouWinMusicCode()
    {
        if (backgroundMusicLevel1.isPlaying)
            backgroundSongLevel1 = false;
        {
            backgroundMusicLevel1.Stop();
        }

        if (!YouWinMusic.isPlaying && GameOverSong == false)
        {
            YouWinMusic.Play();
            YouWinSong = true;
        }
    }


    public void GameOverMusicCode()
    {
        if (backgroundMusicLevel1.isPlaying)
            backgroundSongLevel1 = false;
        {
            backgroundMusicLevel1.Stop();
        }

        if (!GameOverMusic.isPlaying && GameOverSong == false)
        {
            GameOverMusic.Play();
            GameOverSong = true;
        }
    }


    public void PauseCode()
    {
            backgroundMusicLevel1.Pause();
    }

    public void UnPauseCode()
    {
        backgroundMusicLevel1.UnPause();
    }
}