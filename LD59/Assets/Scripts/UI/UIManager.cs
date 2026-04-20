using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI treeCount;
    public TextMeshProUGUI signal;

    public TextMeshProUGUI winText;

    public SignalManager signalManager;


    void Update()
    {
        signal.text = $"{signalManager.currentStrength:F1} dBm";
        treeCount.text = $"Terraformed: \n{(((float)World.trees.Count / 25) * 100):F1}%";

        if (World.trees.Count >= 25)
        {
            Time.timeScale = 0;
            winText.enabled = true;
            signal.enabled = false;
            treeCount.enabled = false;
        }
    }
}
