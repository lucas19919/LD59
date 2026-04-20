using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions controls;

    public Vector2 MouseDelta { get; private set; }
    public Vector2 MouseZoom { get; private set; }
    public bool IsMiddleClicking { get; private set; }
    public bool IsLeftClicking { get; private set; }

    public bool LeftClick => controls.UI.Left.WasPressedThisFrame();
    public bool Plant => controls.UI.Plant.WasPressedThisFrame();
    public bool Place => controls.UI.Place.WasPressedThisFrame();
    public bool Water => controls.UI.Water.WasPressedThisFrame();

    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.UI.MiddleHold.performed += ctx => IsMiddleClicking = true;
        controls.UI.MiddleHold.canceled += ctx => IsMiddleClicking = false;

        controls.UI.LeftHold.performed += ctx => IsLeftClicking = true;
        controls.UI.LeftHold.canceled += ctx => IsLeftClicking = false;
    }

    private void Update()
    {
        MouseDelta = controls.UI.MouseMovement.ReadValue<Vector2>();
        MouseZoom = controls.UI.Scroll.ReadValue<Vector2>();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
}