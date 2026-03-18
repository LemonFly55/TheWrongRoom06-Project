using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light roomLight;

    AudioSource flickerSound;

    void Start()
    {
        flickerSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Random.Range(0, 200) < 1)
        {
            roomLight.enabled = !roomLight.enabled;
            flickerSound.Play();
        }
    }
}