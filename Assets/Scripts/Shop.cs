using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileTurret;
    public TurretBluePrint laserTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
