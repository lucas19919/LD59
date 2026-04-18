using UnityEngine;
using UnityEngine.Assemblies;

public class Connection : MonoBehaviour
{
    public Transform anchor;
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
        if (World.towers.Count < 2) return;

        float currentStrength = 0;
        foreach (SignalTower tower in World.towers)
        {
            Vector3 dir1 = tower.transform.position - anchor.position;
            Vector3 dir2 = this.transform.position - anchor.position;

            float angle = Vector3.Angle(dir1, dir2);
            float distance = angle * anchor.localScale.x;

            float strength = tower.signalStrength / distance;
            if (strength > currentStrength)
            {
                currentStrength = strength;
                connectedTower.isConnected = false;
                connectedTower = tower;
                connectedTower.isConnected = true;

                continue;
            }
        }
    }
}
