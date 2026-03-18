using UnityEngine;

public class CorrectTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.ChooseCorrect();
        }
    }
}
