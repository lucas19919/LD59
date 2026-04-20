using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tree : MonoBehaviour
{
    [Header("Growth Settings")]
    public float growthRate = 0.05f;
    public float maxGrowth = 1.0f;
    public float decayRate = 0.02f;
    public float waterDecay = 0.033f;

    [Header("Resources")]
    [Range(0, 1)] public float water = 1.0f;

    [Header("Visuals")]
    public DecalProjector projector;
    public MeshRenderer leaf;
    public Color healthyColor = Color.green;
    public Color dryColor = new Color(0.6f, 0.5f, 0.2f);

    private float currentGrowth = 0.001f;
    private float highestGrowth = 0.0f;

    private MaterialPropertyBlock propBlock;
    private static readonly int ColorProperty = Shader.PropertyToID("_BaseColor");

    private void Awake()
    {
        World.AddTree(this);
        propBlock = new MaterialPropertyBlock();
    }

    private void Update()
    {
        HandleResources();
        HandleGrowthAndDecay();
        UpdateVisuals();
    }

    private void HandleResources()
    {
        water = Mathf.MoveTowards(water, 0f, waterDecay * Time.deltaTime);
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
        if (leaf != null)
        {
            leaf.GetPropertyBlock(propBlock, 1);

            Color currentColor = Color.Lerp(dryColor, healthyColor, water);
            propBlock.SetColor(ColorProperty, currentColor);

            leaf.SetPropertyBlock(propBlock, 1);
        }
    }
}