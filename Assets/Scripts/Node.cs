using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    public Vector3 positionOffset;

    private GameObject turret;


    private Color startColor;
    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (buildManager.getTurretToBuild() == null) return;

        if(turret != null)
        {
            Debug.Log("Can't Build Here, Turret already exists...");
            return;
        }

        GameObject turretToBuild = buildManager.getTurretToBuild();

        
        
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);


        
    }

    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (buildManager.getTurretToBuild() == null) return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
