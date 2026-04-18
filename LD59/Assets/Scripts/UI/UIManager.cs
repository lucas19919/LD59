using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI treeCount;
    public TextMeshProUGUI signal;

    public SignalManager signalManager;


    void Update()
    {
        signal.text = $"Signal Strength: {signalManager.currentStrength:F1}";
        treeCount.text = $"Trees Planted: {World.trees.Count}";
    }
}
