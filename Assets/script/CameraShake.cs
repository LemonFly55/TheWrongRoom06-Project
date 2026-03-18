using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = startPos + Random.insideUnitSphere * 0.002f;
    }
}