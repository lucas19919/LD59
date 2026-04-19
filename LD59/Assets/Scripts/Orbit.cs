using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform anchor;
    public float speed = 10.0f;

    void Update()
    {
        transform.RotateAround(anchor.position, Vector3.up, speed * Time.deltaTime);
    }
}
