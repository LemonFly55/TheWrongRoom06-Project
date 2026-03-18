using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    Vector3 startPos;
    bool isActive = false;

    public float shakeAmount = 0.02f;
    public float shakeSpeed = 10f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (!isActive) return;

        float x = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
        float z = Mathf.Cos(Time.time * shakeSpeed) * shakeAmount;

        transform.position = startPos + new Vector3(x, 0, z);
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
        transform.position = startPos;
    }
}