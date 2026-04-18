using UnityEngine;

public class SignalManager : MonoBehaviour
{
    public float currentStrength = 100.0f;
    public float signalDecay = 30.0f;
    public Connection connection;

    private void Update()
    {
        currentStrength += (connection.signalStrength - signalDecay) * Time.deltaTime;
        currentStrength = Mathf.Clamp(currentStrength, 0, 100);
    }
}
