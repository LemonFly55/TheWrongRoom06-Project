using UnityEngine;

public class TutorialNote : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject pressEText;

    AudioSource paperSound;

    bool playerInRange = false;

    void Start()
    {
        paperSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            tutorialPanel.SetActive(!tutorialPanel.activeSelf);
            paperSound.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            pressEText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            pressEText.SetActive(false);
        }
    }
}