using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tree : MonoBehaviour
{
    public float growthRate = 0.1f;
    public float currentGrowth = 0.001f;
    public float maxGrowth = 1.0f;

    public float decayRate = 0.05f;

    public float water = 1.0f;
    public float fertilizer = 1.0f;

    private float highestGrowth = 0.0f;

    public DecalProjector projector;

    private void Awake()
    {
        World.AddTree(this);
    }

    private void Update()
    {
        if (currentGrowth < maxGrowth)
        {
            if (currentGrowth > highestGrowth)
                highestGrowth = currentGrowth;

            currentGrowth += ((growthRate * fertilizer) - (decayRate * (1 - water))) * Time.deltaTime;
            currentGrowth = Mathf.Clamp(currentGrowth, 0, maxGrowth);

            transform.localScale = Vector3.one * highestGrowth;
        }

        if (currentGrowth == 0) Destroy(this.gameObject);

        water -= decayRate * Time.deltaTime;
        fertilizer -= decayRate * Time.deltaTime;

        water = Mathf.Clamp(water, 0.0f, 1.0f);
        fertilizer = Mathf.Clamp(fertilizer, 0.0f, 1.0f);
    }
}
