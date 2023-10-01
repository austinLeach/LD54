using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class inbetween1 : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource sfx;
    public AudioClip clip;
    void Start()
    {
        audio.time = GlobalVariables.timeInAudio;
    }
    public void PlayGame()
    {
        sfx.PlayOneShot(clip);
        GlobalVariables.timeInAudio = audio.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        sfx.PlayOneShot(clip);
        GlobalVariables.timeInAudio = 0f;
        SceneManager.LoadScene(0);
    }
}
