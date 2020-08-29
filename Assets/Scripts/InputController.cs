using UnityEngine;

public class InputController : MonoBehaviour
{
    public Transform sticksParent;
    public Transform leftStick;
    public Transform rightStick;

    public float rollSensitivity;
    public float pinchSensitivity;

    public new Camera camera;

    public bool collidingWithTop;
    public bool collidingWithBottom;
    public bool collidingWithFloor;
    public bool collidingWithFood;
    public bool collidingWithAssembly;

    public Food food;

    public bool leftStickCollision;
    public bool rightStickCollision;

    public float timer;
    public float dropInSeconds = 5;


    private void Start()
    {
        this.collidingWithBottom = false;
        this.collidingWithTop = false;
        this.collidingWithFloor = false;
        this.collidingWithAssembly = false;
        this.collidingWithFood = false;

        this.leftStickCollision = false;
        this.rightStickCollision = false;
        this.food = null;
    }

    private void Update()
    {
        //Mouse input
        this.MoveSticks();


        if (this.leftStickCollision && this.rightStickCollision && this.collidingWithFood)
        {
            this.timer -= Time.deltaTime;

            if (this.timer < 1) this.camera.GetComponent<CameraShake>().shakeDuration = Time.deltaTime;

            if (this.timer <= 0)
            {
                this.leftStick.eulerAngles = new Vector3(0, 0, -6.5f);
                this.rightStick.eulerAngles = new Vector3(0, 0, 6.5f);
            }
        }
        else
        {
            this.timer = this.dropInSeconds;
            this.sticksParent.eulerAngles = Vector3.zero;
        }


        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            if (this.collidingWithBottom || this.leftStickCollision && this.rightStickCollision) return;

            this.RollStick(-this.rollSensitivity);
        }

        if (!Input.GetKey(KeyCode.Joystick1Button5)) return;
        if (this.collidingWithTop) return;

        this.RollStick(this.rollSensitivity);
    }

    private void MoveSticks()
    {
        float moveX = Input.GetAxisRaw("Move X");
        float moveY = Input.GetAxisRaw("Move Y");
        float moveAltitude = Input.GetAxisRaw("Move Altitude");

        if ((this.collidingWithFloor || this.collidingWithAssembly) && moveAltitude < 0) return;

        if (this.leftStickCollision && this.rightStickCollision && this.collidingWithFood)
        {
            this.food.EnableGravity(false);
            this.food.transform.position += new Vector3(moveX * Time.deltaTime * 2, moveAltitude * Time.deltaTime,
                moveY * Time.deltaTime * 2);
        }
        else
        {
            if (this.food != null)
            {
                this.food.EnableGravity(true);
                this.food = null;
            }
        }

        this.leftStick.position += new Vector3(moveX * Time.deltaTime * 2, moveAltitude * Time.deltaTime,
            moveY * Time.deltaTime * 2);
        this.rightStick.position += new Vector3(moveX * Time.deltaTime * 2, moveAltitude * Time.deltaTime,
            moveY * Time.deltaTime * 2);
    }

    private void RollStick(float amount)
    {
        this.leftStick.Rotate(Vector3.back * amount, Space.World);
        this.rightStick.Rotate(Vector3.forward * amount, Space.World);
    }
}