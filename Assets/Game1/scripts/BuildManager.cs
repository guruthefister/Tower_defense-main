using System;
using UnityEditor;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    
    public static BuildManager instance; 

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;

    internal TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
     
    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        Vector3 buildposition = turretToBuild.prefab.GetComponent<Turret>().positionOffset;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(buildposition), Quaternion.identity); 
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    public void SelectNode (Node node)
    {
        selectedNode = node;
        turretToBuild = null;

        node.turretPositionOffset = node.turret.GetComponent<Turret>().positionOffset;
        nodeUI.SetTarget(node);
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

}
