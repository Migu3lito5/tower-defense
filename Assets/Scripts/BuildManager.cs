
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    private GameObject turretToBuild;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

  
    
    public GameObject getTurretToBuild ()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
