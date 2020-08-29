using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject stain;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
            Instantiate(this.stain, new Vector3(other.transform.position.x, 0.14f, other.transform.position.z),
                Quaternion.identity);
    }
}