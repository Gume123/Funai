using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start() //Para a cor do Material do Node se manter
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown() //Ao clicar a torre aparece, Instanciamos a torre em um Manager em outro código
    {
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            return;
        }

        buildManager.BuildTurretOn(this);
    }
    void OnMouseEnter() //Quando passar o mouse por cima de um Node, ele brilhar
    {
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit() //Aqui o Node volta a sua cor original 
    {
        rend.material.color = startColor;
    }
}
