using UnityEngine;

public class Insantiate : MonoBehaviour
{
    public void InstantiateTower()
    {
        World.AddTower(Instantiate(Resources.Load<SignalTower>("Prefabs/SignalTower"), transform.position, Quaternion.identity));
    }

    public void PlantTree()
    {
        World.AddTree(Instantiate(Resources.Load<Tree>("Prefabs/Seed"), transform.position, Quaternion.identity));
    }
}
