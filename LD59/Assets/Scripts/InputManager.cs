using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions controls;

    public Vector2 MouseDelta { get; private set; }
    public Vector2 MouseZoom { get; private set; }
    public bool IsMiddleClicking { get; private set; }

    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.UI.Orbit.performed += ctx => IsMiddleClicking = true;
        controls.UI.Orbit.canceled += ctx => IsMiddleClicking = false;
    }

    private void Update()
    {
        MouseDelta = controls.UI.MouseMovement.ReadValue<Vector2>();
        MouseZoom = controls.UI.MouseZoom.ReadValue<Vector2>();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
}
