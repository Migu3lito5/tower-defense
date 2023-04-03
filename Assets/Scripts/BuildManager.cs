
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    
    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

  
    public bool CanBuild { get { return turretToBuild != null;  } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode (Node node)
    {

        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }


}
