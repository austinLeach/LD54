using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource sfx;
    public AudioClip clip;
    private void Start()
    {
        audio.time = GlobalVariables.timeInAudio;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySound()
    {
        sfx.PlayOneShot(clip);
    }
}
