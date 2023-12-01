using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;


    public int GetSellAmount (bool isUpgraded)
    {
        if (isUpgraded)
        {
            return (cost + upgradeCost) / 2;
        }
        return (cost) / 2;
    }
}