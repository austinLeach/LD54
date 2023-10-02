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
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWinScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        winCanvas.SetActive(true);
        Time.timeScale = .5f;
    }

    public void ShowLoseScreen() {
        Cursor.lockState = CursorLockMode.None;
        loseCanvas.SetActive(true);
        Time.timeScale = .5f;
    }

    public void NextLevel()
    {
        GlobalVariables.timeInAudio =  audio.time;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Next Level=======================");
    }

    public void RestartLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GlobalVariables.timeInAudio = audio.time;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
