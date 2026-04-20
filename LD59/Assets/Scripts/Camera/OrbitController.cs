using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class OrbitController : MonoBehaviour
{
    [Header("References")]
    public InputManager input;
    public Transform anchor;

    [Header("Settings")]
    public float cameraDistance = 30.0f;
    public float orbitSensitivity = 25.0f;
    public float zoomSensitivity = 50.0f;
    public float minZoomDistance = 20.0f;
    public float maxZoomDistance = 50.0f;
    public float smoothSpeed = 5.0f;

    private float targetDistance;
    private float currentDistance;
    private Quaternion targetRotation;

    void Awake()
    {
        Vector3 dir = this.transform.position - anchor.position;

        targetDistance = dir.magnitude;
        currentDistance = targetDistance;
        targetRotation = this.transform.rotation;

        if (currentDistance != cameraDistance)
        {
            dir = dir.normalized * cameraDistance;
            this.transform.position = anchor.position + dir;
        }
    }

    private void Update()
    {
        if (input.IsMiddleClicking)
        {
            Vector2 mouseDelta = input.MouseDelta;
            float angleX = mouseDelta.x * orbitSensitivity * Time.deltaTime;
            float angleY = mouseDelta.y * orbitSensitivity * Time.deltaTime;

            targetRotation *= Quaternion.Euler(-angleY, angleX, 0);
        }

        float scroll = -input.MouseZoom.y;
        if (scroll != 0)
        {
            targetDistance += scroll * zoomSensitivity * Time.deltaTime;
            targetDistance = Mathf.Clamp(targetDistance, minZoomDistance, maxZoomDistance);
        }

        currentDistance = Mathf.Lerp(currentDistance, targetDistance, smoothSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
        transform.position = anchor.position - transform.forward * currentDistance;
    }
}
