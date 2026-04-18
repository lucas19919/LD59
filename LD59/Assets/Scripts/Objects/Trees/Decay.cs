using UnityEngine;

public class Decay : MonoBehaviour
{
    public Material leaves;
    public Color alive;
    public Color dead;

    private Tree tree;

    private void Awake()
    {
        tree = GetComponent<Tree>();
    }

    private void Update()
    {
        Color color = Color.Lerp(dead, alive, tree.currentGrowth / tree.maxGrowth);
        leaves.SetColor("_BaseColor", color);
    }
}
