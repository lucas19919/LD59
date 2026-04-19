using UnityEngine;
using UnityEngine.Assemblies;

public class Connection : MonoBehaviour
{
    public Transform anchor;
    public float signalStrength { get; private set; }

    private SignalTower connectedTower;

    private void Start()
    {
        if (World.towers.Count > 0)
        {
            connectedTower = World.towers[0];
        }
    }

    private void Update()
    {
        if (World.towers.Count < 2) 
        {
            if (World.towers.Count == 0)
            {
                signalStrength = 0;
                connectedTower = null;
            }
            else
            {
                connectedTower.isConnected = true;
                signalStrength = connectedTower.signalStrength / (Vector3.Distance(this.transform.position, connectedTower.transform.position) * Mathf.PI);
            }

            return;
        }

        float currentStrength = 0;
        foreach (SignalTower tower in World.towers)
        {
            Vector3 dir1 = tower.transform.position - anchor.position;
            Vector3 dir2 = this.transform.position - anchor.position;

            float angle = (Mathf.PI * Vector3.Angle(dir1, dir2)) / 180.0f;
            float distance = angle * anchor.localScale.x;

            float strength = tower.signalStrength / distance;
            if (strength > currentStrength)
            {
                currentStrength = strength;
                connectedTower.isConnected = false;
                connectedTower = tower;
                connectedTower.isConnected = true;
                signalStrength = strength;

                continue;
            }
        }
    }
}
