using UnityEngine;

public class ServingBowl : MonoBehaviour
{
    public int points;
    public int foodInsideBowl;
    public int requiredFoodToWin = 5;
    public InGameMenu inGameMenu;
    public bool won;

    public AudioSource bowlFill;
    public AudioClip hitSound;

    private void Start()
    {
        this.won = false;
        this.foodInsideBowl = 0;
    }

    private void Update()
    {
        if (this.won) return;

        if (this.foodInsideBowl != this.requiredFoodToWin) return;

        this.won = true;
        this.points = 1000000 - (int) Time.timeSinceLevelLoad * 1000;
        this.inGameMenu.inGameMenu.SetActive(true);
        this.inGameMenu.highScore.text = "Score: " + this.points;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Food")) return;

        Food food = other.GetComponent<Food>();

        if (food.insideBowl) return;

        this.bowlFill.PlayOneShot(this.hitSound);

        food.insideBowl = true;
        this.foodInsideBowl++;
    }
}