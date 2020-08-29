using UnityEngine;

public class MenuRotator : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //  transform.rotation.x;
        Quaternion rotation = this.transform.rotation;
        this.transform.Rotate(new Vector3(rotation.x, 90 * Time.deltaTime, rotation.z));
    }
}