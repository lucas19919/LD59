using UnityEngine;

public class RobotController : MonoBehaviour
{
    [Header("References")]
    public InputManager input;

    [Header("Settings")]
    public float movementSpeed = 5.0f;
    public float joystickDeadzone = 0.2f;
    public float joystickSensitivity = 1.0f;

    private void Update()
    {
        
    }
}
