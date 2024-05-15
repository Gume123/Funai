using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //Criamos essa vari�vel para  n�o ter um BuildManager em cada Node, deixando o jogo mais pesado, ela cuida de construir as torres

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // Destruir o objeto BuildManager atual
            return;
        }
        instance = this;
    }

    public GameObject torre1Prefab;
    public GameObject torre2Prefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return StatusDoJogador.Dinheiro >= turretToBuild.custo; } }

    public void BuildTurretOn(Node node) // Constr�i a torre no Node caso o jogador tenha o dinheiro necess�rio para isso
    {
        if (StatusDoJogador.Dinheiro < turretToBuild.custo)
        {
            return;
        }

        StatusDoJogador.Dinheiro -= turretToBuild.custo;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Constru�da!Dinheiro restante: " + StatusDoJogador.Dinheiro);
    }

    public void SelectTurretToBuild (TurretBlueprint turret) //"Contruir" a torre
    {
        turretToBuild = turret;
    }

}
