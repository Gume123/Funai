using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Usamos essa classe para que a Unity deixe visível, salve e carrege os valores e preços das turrets para a gente.
public class TurretBlueprint
{
    public GameObject prefab;
    public int custo;
}
