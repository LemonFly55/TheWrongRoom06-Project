using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    public GameObject[] normalObjects;
    public GameObject[] anomalyObjects;
    public ExtraObjectAnomaly[] extraAnomalies;
    public ShakeObject fridgeShake;

    void Start()
    {
        int random = Random.Range(0, anomalyObjects.Length);

        for (int i = 0; i < normalObjects.Length; i++)
        {
            normalObjects[i].SetActive(true);
            anomalyObjects[i].SetActive(false);
        }

        if (Random.value > 0.5f)
        {
            TriggerAnomaly(random);
        }
    }

    void TriggerAnomaly(int index)
    {
        normalObjects[index].SetActive(false);
        anomalyObjects[index].SetActive(true);
    }

    public void SetAnomaly()
    {
        int type = Random.Range(0, 3);

        if (type == 0 && anomalyObjects.Length > 0)
        {
            int random = Random.Range(0, anomalyObjects.Length);
            TriggerAnomaly(random);
        }
        else if (type == 1 && extraAnomalies.Length > 0)
        {
            int random = Random.Range(0, extraAnomalies.Length);
            extraAnomalies[random].Activate();
        }
        else
        {
            fridgeShake.Activate();
        }
    }

    public void ResetObjects()
    {
        Debug.Log("RESET");

        for (int i = 0; i < normalObjects.Length; i++)
        {
            normalObjects[i].SetActive(true);
            anomalyObjects[i].SetActive(false);
        }

        foreach (var anomaly in extraAnomalies)
        {
            anomaly.ResetObject();
        }
        fridgeShake.Deactivate();
    }
}