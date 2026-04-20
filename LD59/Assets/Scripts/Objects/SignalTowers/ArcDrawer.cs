using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SphericalArcDrawer : MonoBehaviour
{
    public Transform sphereCenter;
    public Transform startPoint;
    public float arcHeight = 0.5f;
    public int resolution = 20;
    public float scrollSpeed = 0.05f;

    private LineRenderer lineRenderer;
    private int baseMapID;
    private Material cachedMaterial;
    private Connection connection;
    private float currentOffset;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.textureMode = LineTextureMode.Tile;
        cachedMaterial = lineRenderer.material;
        baseMapID = Shader.PropertyToID("_BaseMap");
        connection = GetComponent<Connection>();
    }

    private void Update()
    {
        if (connection == null || connection.connectedTower == null)
        {
            lineRenderer.positionCount = 0;
            return;
        }

        Transform endPoint = connection.connectedTower.arc;
        if (sphereCenter == null || startPoint == null || endPoint == null) return;

        DrawSphericalArc(endPoint);
        AnimateSignal();
    }

    private void DrawSphericalArc(Transform endPoint)
    {
        lineRenderer.positionCount = resolution + 1;

        Vector3 startRel = startPoint.position - sphereCenter.position;
        Vector3 endRel = endPoint.position - sphereCenter.position;

        for (int i = 0; i <= resolution; i++)
        {
            float t = i / (float)resolution;
            Vector3 currentDirection = Vector3.Slerp(startRel, endRel, t);
            float heightAddition = Mathf.Sin(t * Mathf.PI) * arcHeight;
            Vector3 currentPosition = sphereCenter.position + currentDirection + (currentDirection.normalized * heightAddition);
            lineRenderer.SetPosition(i, currentPosition);
        }
    }

    private void AnimateSignal()
    {
        currentOffset += scrollSpeed * connection.signalStrength * 0.4f * Time.deltaTime;
        cachedMaterial.SetTextureOffset(baseMapID, new Vector2(currentOffset, 0));
    }
}