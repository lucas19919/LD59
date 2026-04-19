using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public InputManager input;
    public SignalManager signalManager;

    public GameObject towerPrefab;
    public GameObject treePrefab;

    public void InstantiateTower()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 5.0f);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Tower"))
            {
                Debug.Log("Too close to another tower!");
                return;
            }
        }

        signalManager.currentStrength -= 50.0f;
        GameObject tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
    }

    public void PlantTree()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 2.0f);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Tree"))
            {
                Debug.Log("Too close to another Tree!");
                return;
            }
        }

        signalManager.currentStrength -= 25.0f;
        GameObject tree = Instantiate(treePrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (input.Place && signalManager.currentStrength > 50.0f)
        {
            Debug.Log("Placing...");
            InstantiateTower();
        }
        if (input.Plant && signalManager.currentStrength > 25.0f)
        {
            Debug.Log("Planting...");
            PlantTree();
        }
    }
}
