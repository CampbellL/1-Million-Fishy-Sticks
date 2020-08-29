using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject food1, food2, food3, food4, food5, food6, food7, food8, bowl;
    public Transform spawnLocation;

    private int _itemToBeSpawned;
    private float _nextSpawn;

    private void Update()
    {
        if (!(Time.time > this._nextSpawn)) return;
        // var itemBowl = Instantiate(this.bowl, spawnLocation.position, new Quaternion(0f, 0f, 0f, 0f));
        this._itemToBeSpawned = Random.Range(1, 9);
        Vector3 position = this.transform.position;
        Vector3 spawnPoint = new Vector3(
            position.x,
            position.y + 0.3f,
            position.z
        );
        switch (this._itemToBeSpawned)
        {
            case 1:
                Instantiate(this.food1, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 2:
                Instantiate(this.food2, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 3:
                Instantiate(this.food3, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 4:
                Instantiate(this.food4, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 5:
                Instantiate(this.food5, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 6:
                Instantiate(this.food6, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 7:
                Instantiate(this.food7, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 8:
                Instantiate(this.food8, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
            default:
                Instantiate(this.food1, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
                break;
        }

        this._nextSpawn = Time.time + this.spawnRate;
    }
}