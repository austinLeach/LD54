using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class WinScreen : MonoBehaviour
{ 
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWinScreen()
    {
        winCanvas.SetActive(true);
        Time.timeScale = .5f;
    }

    public void ShowLoseScreen() { 
        loseCanvas.SetActive(true);
        Time.timeScale = .5f;
    }

    public void NextLevel()
    {
        GlobalVariables.timeInAudio =  audio.time;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        GlobalVariables.timeInAudio = audio.time;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
