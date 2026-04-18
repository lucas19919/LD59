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

    private SignalManager signalManager;
    private Care care;

    private void Awake()
    {
        signalManager = GetComponent<SignalManager>();
    }

    private void Update()
    {
        Vector3 normal = (this.transform.position - anchor.transform.position).normalized;

        Vector3 right = satellite.right;
        Vector3 up = satellite.up;

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

        //get button inputs from dash
        if (care != null)
        {
            if (input.Water)
                care.Water(signalManager);
            if (input.Water)
                care.Fertilize(signalManager);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            care = other.gameObject.GetComponent<Care>();
            //draw something to show that it's selected
        }
    }

    private void OnTriggerExit(Collider other)
    {
        care = null;
        //remove selection indicator
    }
}   