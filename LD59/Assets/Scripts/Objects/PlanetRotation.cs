using Unity.VisualScripting;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float height = 1.0f;

    private Transform anchor;

    private void Awake()
    {
        anchor = GameObject.Find("Earth").transform;
    }

    private void Update()
    {
        SphereRotation(anchor, this.transform);
    }

    public void SphereRotation(Transform anchor, Transform body)
    {
        Quaternion rot = Quaternion.LookRotation(body.position - anchor.position, Vector3.up);
        body.rotation = rot;

        Vector3 dir = body.position - anchor.position;
        float distance = dir.magnitude;

        if (distance == 0) dir = body.up;

        body.position = anchor.position + (dir.normalized * anchor.localScale.x * 0.5f) + (dir.normalized * height * this.transform.localScale.z);
    }

}
