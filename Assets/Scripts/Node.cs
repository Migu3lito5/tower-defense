using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    public TurretBluePrint turretBluePrint;
    public bool isUpgraded = false;


    private Color startColor;
    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) return;

        BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret (TurretBluePrint bluePrint)
    {
        
        if (PlayerStats.Money < bluePrint.cost) return;

        PlayerStats.Money -= bluePrint.cost;

        GameObject turret = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        turretBluePrint = bluePrint;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost) return;

        PlayerStats.Money -= turretBluePrint.upgradeCost;

        Destroy(this.turret);

        GameObject turret = (GameObject)Instantiate(turretBluePrint.upgradedprefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();
        Destroy(this.turret);
        turretBluePrint = null;
    }

    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney)
            rend.material.color = hoverColor;
        else
            rend.material.color = notEnoughMoneyColor;

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
