using UnityEngine;

public class PictureAnomaly : MonoBehaviour
{
    public GameObject normalPicture;
    public GameObject anomalyPicture;

    public void Activate()
    {
        normalPicture.SetActive(false);
        anomalyPicture.SetActive(true);
    }

    public void ResetObject()
    {
        normalPicture.SetActive(true);
        anomalyPicture.SetActive(false);
    }
}