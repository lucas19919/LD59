using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions controls;

    public Vector2 MouseDelta { get; private set; }
    public Vector2 MouseZoom { get; private set; }
    public bool IsMiddleClicking { get; private set; }
    public bool IsLeftClicking { get; private set; }
    public bool LeftClick { get; private set; }

    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.UI.MiddleHold.performed += ctx => IsMiddleClicking = true;
        controls.UI.MiddleHold.canceled += ctx => IsMiddleClicking = false;

        controls.UI.LeftHold.performed += ctx => IsLeftClicking = true;
        controls.UI.LeftHold.canceled += ctx => IsLeftClicking = false;

        controls.UI.Left.performed += ctx => LeftClick = true;
        controls.UI.Left.canceled += ctx => LeftClick = false;
    }

    private void Update()
    {
        MouseDelta = controls.UI.MouseMovement.ReadValue<Vector2>();
        MouseZoom = controls.UI.Scroll.ReadValue<Vector2>();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
}
