using UnityEngine;

public class Stick : MonoBehaviour
{
    public bool isLeftStick;
    private InputController _inputController;

    private void Start()
    {
        this._inputController = GameObject.FindWithTag("GameController").GetComponent<InputController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Top") this._inputController.collidingWithTop = true;

        if (other.transform.name == "Bottom") this._inputController.collidingWithBottom = true;

        if (other.transform.name == "Floor") this._inputController.collidingWithFloor = true;

        if (other.transform.name == "Assembly") this._inputController.collidingWithFloor = true;

        if (other.CompareTag("Food"))
        {
            this._inputController.collidingWithFood = true;
            this._inputController.food = other.transform.GetComponent<Food>();
            this._inputController.food.origin = other.transform;

            if (this.isLeftStick)
                this._inputController.leftStickCollision = true;
            else
                this._inputController.rightStickCollision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Top") this._inputController.collidingWithTop = false;

        if (other.transform.name == "Bottom") this._inputController.collidingWithBottom = false;

        if (other.transform.name == "Floor") this._inputController.collidingWithFloor = false;

        if (other.transform.name == "Assembly") this._inputController.collidingWithFloor = false;

        if (other.CompareTag("Food"))
        {
            this._inputController.collidingWithFood = false;

            if (this.isLeftStick)
                this._inputController.leftStickCollision = false;
            else
                this._inputController.rightStickCollision = false;
        }
    }
}