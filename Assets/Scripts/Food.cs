using UnityEngine;

public class Food : MonoBehaviour
{
    public Transform origin;
    public bool insideBowl;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "Assembly") this.transform.position += Vector3.left * Time.deltaTime;
    }


    public void MoveFood(Vector3 newPosition)
    {
        this.origin.position += newPosition;
    }

    public void MoveFood(Vector3 newPosition, Transform food)
    {
        this.origin.position += newPosition;
    }

    public void EnableGravity(bool state)
    {
        this.GetComponent<Rigidbody>().useGravity = state;
    }
}