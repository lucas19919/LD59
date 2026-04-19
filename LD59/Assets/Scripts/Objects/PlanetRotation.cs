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
        if (anchor != null)
        {
            SphereRotation(anchor, this.transform);
        }
    }

    public void SphereRotation(Transform anchor, Transform body)
    {
        Vector3 dir = (body.position - anchor.position).normalized;
        if (dir == Vector3.zero) dir = body.up;

        body.rotation = Quaternion.FromToRotation(body.up, dir) * body.rotation;

        body.position = anchor.position + (dir * anchor.localScale.x * 0.5f) + (dir * height * body.localScale.z);
    }
}