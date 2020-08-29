using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;

    [FormerlySerializedAs("highscore")] public Text highScore;


    private void Start()
    {
        this.inGameMenu.SetActive(false);
    }
}