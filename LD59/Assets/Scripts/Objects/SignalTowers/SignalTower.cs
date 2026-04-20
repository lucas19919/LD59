using UnityEngine;

public class SignalTower : MonoBehaviour
{
    public float signalStrength = 1.0f;
    public float range = 10.0f;
    public bool isConnected = false;
    
    public Transform arc;

    public Material connected;
    public Material disconnected;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        World.AddTower(this);
    }

    private void Update()
    {
        meshRenderer.material = isConnected ? connected : disconnected;
    }
}
