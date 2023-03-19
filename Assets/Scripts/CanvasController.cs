using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject startScreen,gameScreen,tryAgainScreen,stopButton,startButton,muteButton,volumeButton;
    public PlayerController PlayerController;
    public CarSpawnerController SpawnerController;
    public Text scoreText, scoreText2, highScoreText, highScoreText2;
    public int score;
    public AudioSource carAudioSource,audioSource;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(score>PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
       
        highScoreText.text=PlayerPrefs.GetInt("highScore").ToString();
        highScoreText2.text = PlayerPrefs.GetInt("highScore").ToString();





    }
    public void StartButton()
    {
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
        SpawnerController.CarSpawner();
        InvokeRepeating("Score", 1f, 1f);
        carAudioSource.Play();

    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
    public void GameStopButton()
    {
        Time.timeScale = 0;
        stopButton.SetActive(false);
        startButton.SetActive(true) ;
        carAudioSource.Pause();
    }
    public void GameStartButton()
    {
        Time.timeScale = 1;
        stopButton.SetActive(true);
        scoreText.text = 0.ToString();
        startButton.SetActive(false);
        carAudioSource.Play();
    }
    public void Score()
    {
        score += 1;
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
    }
    public void MuteButton()
    {
        muteButton.SetActive(false);
        volumeButton.SetActive(true);
        audioSource.Stop();

    }
    public void VolumeButton()
    {
        muteButton.SetActive(true);
        volumeButton.SetActive(false);
        audioSource.Play();
    }


}
