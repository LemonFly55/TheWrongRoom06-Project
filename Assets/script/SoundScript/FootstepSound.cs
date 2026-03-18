using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float stepDelay = 0.5f;

    AudioSource audioSource;
    float stepTimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") + Input.GetAxis("Vertical");

        if (move != 0)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0)
            {
                PlayFootstep();
                stepTimer = stepDelay;
            }
        }
        else
        {
            stepTimer = 0;
        }
    }

    void PlayFootstep()
    {
        int random = Random.Range(0, footstepSounds.Length);
        audioSource.PlayOneShot(footstepSounds[random]);
    }
}