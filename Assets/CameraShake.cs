using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    private Vector3 _originalPos;

    private void Awake()
    {
        if (this.camTransform == null) this.camTransform = this.GetComponent(typeof(Transform)) as Transform;
    }

    private void Update()
    {
        if (this.shakeDuration > 0)
        {
            this.camTransform.localPosition = this._originalPos + Random.insideUnitSphere * this.shakeAmount;

            this.shakeDuration -= Time.deltaTime * this.decreaseFactor;
        }
        else
        {
            this.shakeDuration = 0f;
            this.camTransform.localPosition = this._originalPos;
        }
    }

    private void OnEnable()
    {
        this._originalPos = this.camTransform.localPosition;
    }
}