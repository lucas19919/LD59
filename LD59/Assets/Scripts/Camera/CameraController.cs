using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraDistance = 10.0f;
    public float sensitivity = 5.0f;
    public Transform anchor;

    void Awake()
    {
        Vector3 dir = this.transform.position - anchor.position;
        float distance = dir.magnitude;

        if (distance != cameraDistance)
        {
            dir = dir.normalized * cameraDistance;
            this.transform.position = anchor.position + dir;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            float horizontal = Input.GetAxis("Mouse X") * sensitivity;
            float vertical = Input.GetAxis("Mouse Y") * sensitivity;
            this.transform.RotateAround(anchor.position, Vector3.up, horizontal);
            this.transform.RotateAround(anchor.position, this.transform.right, -vertical);
        }
    }
}
