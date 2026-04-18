using UnityEngine;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Transform anchor;

    public InputManager input;
    public Transform satellite;

    private Vector3 dragCenter;
    private Vector3 mousePosition;

    private void Update()
    {
        Vector3 normal = (this.transform.position - anchor.transform.position).normalized;

        Vector3 right = satellite.right;
        Vector3 up = satellite.up;

        Debug.DrawLine(this.transform.position, this.transform.position + satellite.right, Color.yellow);
        Debug.DrawLine(this.transform.position, this.transform.position + satellite.up, Color.green);

        if (input.LeftClick && !input.IsLeftClicking)
        {
            dragCenter = Pointer.current.position.ReadValue();
        }

        if (input.IsLeftClicking)
        {
            mousePosition = Pointer.current.position.ReadValue();
            Vector3 delta = (mousePosition - dragCenter).normalized;

            Vector3 movement = (right * delta.x + up * delta.y) * movementSpeed * Time.deltaTime;
            this.transform.position += movement;
        }
    }
}   