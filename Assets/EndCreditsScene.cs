using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditsScene : MonoBehaviour
{
    public void LoadNewScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}