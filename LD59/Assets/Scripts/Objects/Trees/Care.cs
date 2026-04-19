using UnityEngine;

public class Care : MonoBehaviour
{
    private Tree tree;

    private void Awake()
    {
        tree = GetComponent<Tree>();
    }

    public void Water(SignalManager signal)
    {
        if (signal.currentStrength > 10.0f)
        {
            signal.currentStrength -= 10.0f;
            tree.water = 1.0f;
        }
    }
}
