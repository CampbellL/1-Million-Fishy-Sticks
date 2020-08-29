using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip clickFx;

    private void ClickSound()
    {
        this.audioPlayer.PlayOneShot(this.clickFx);
    }

    public void PlayGame()
    {
        this.ClickSound();
        SceneManager.LoadScene("Scene");
    }

    public void SeeCredits()
    {
        this.ClickSound();
        SceneManager.LoadScene("CreditsScene");
    }

    public void QuitGame()
    {
        this.ClickSound();
        Application.Quit();
    }
}