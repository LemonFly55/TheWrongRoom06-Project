using UnityEngine;

public class CatAnomaly : ExtraObjectAnomaly
{
    public GameObject cat;

    public override void Activate()
    {
        cat.SetActive(true);
    }

    public override void ResetObject()
    {
        cat.SetActive(false);
    }
}