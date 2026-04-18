using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public InputManager input;
    public SignalManager signalManager;

    public GameObject towerPrefab;
    public GameObject treePrefab;

    public void InstantiateTower()
    {
        GameObject tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
        World.AddTower(tower.GetComponent<SignalTower>());
    }

    public void PlantTree()
    {
        GameObject tree = Instantiate(treePrefab, transform.position, Quaternion.identity);
        World.AddTree(tree.GetComponent<Tree>());
    }

    private void Update()
    {
        if (input.Place && signalManager.currentStrength > 50.0f)
        {
            Debug.Log("Placing...");
            signalManager.currentStrength -= 50.0f;
            InstantiateTower();
        }
        if (input.Plant && signalManager.currentStrength > 25.0f)
        {
            Debug.Log("Planting...");
            signalManager.currentStrength -= 25.0f; 
            PlantTree();
        }
    }
}
