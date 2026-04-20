using UnityEngine;
using UnityEngine.Assemblies;

public class Connection : MonoBehaviour
{
    public Transform anchor;
    public float signalStrength { get; private set; }

    public SignalTower connectedTower;

    private LineRenderer lr;

    private void Start()
    {
        if (World.towers.Count > 0)
        {
            connectedTower = World.towers[0];
        }

        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (World.towers.Count == 0)
        {
            signalStrength = 0;
            connectedTower = null;
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

                //SoundManager.Signal();

                continue;
            }
        }

        lr.material.SetFloat("_Strength", signalStrength);
    }
}
