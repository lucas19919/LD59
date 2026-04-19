using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tree : MonoBehaviour
{
    [Header("Growth Settings")]
    public float growthRate = 0.1f;
    public float maxGrowth = 1.0f;
    public float decayRate = 0.05f;

    [Header("Resources")]
    [Range(0, 1)] public float water = 1.0f;

    [Header("Visuals")]
    public DecalProjector projector;
    public Material leafMaterial;
    public Color healthyColor = Color.green;
    public Color dryColor = new Color(0.6f, 0.5f, 0.2f);

    private float currentGrowth = 0.001f;
    private float highestGrowth = 0.0f;

    private void Awake()
    {
        World.AddTree(this);
    }

    private void Update()
    {
        HandleResources();
        HandleGrowthAndDecay();
        UpdateVisuals();
    }

    private void HandleResources()
    {
        water = Mathf.MoveTowards(water, 0f, decayRate * Time.deltaTime);
    }

    private void HandleGrowthAndDecay()
    {
        if (water > 0)
        {
            if (currentGrowth < maxGrowth)
            {
                currentGrowth += growthRate * Time.deltaTime;
            }
        }
        else
        {
            currentGrowth -= decayRate * Time.deltaTime;
        }

        currentGrowth = Mathf.Clamp(currentGrowth, 0, maxGrowth);

        if (currentGrowth > highestGrowth)
            highestGrowth = currentGrowth;

        transform.localScale = Vector3.one * (water > 0 ? highestGrowth : currentGrowth);

        if (currentGrowth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateVisuals()
    {
        if (leafMaterial != null)
        {
            leafMaterial.color = Color.Lerp(dryColor, healthyColor, water);
        }
    }
}