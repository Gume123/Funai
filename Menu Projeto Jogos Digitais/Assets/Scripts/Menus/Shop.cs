using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint torre1;
    public TurretBlueprint torre2;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelecionarTorre1() //Script para selecionar a compra da primeira torre
    {
        buildManager.SelectTurretToBuild(torre1);
    }
    public void SelecionarTorre2() //Script para selecionar a compra da segunda torre
    {
        buildManager.SelectTurretToBuild(torre2);
    }
}
