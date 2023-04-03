using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefab;
    public int cost;


    public GameObject upgradedprefab;
    public int upgradeCost;

    public int GetSellAmount ()
    {
        return cost / 2;
    }
}
