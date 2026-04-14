using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BurnerKnob[] knobs;
    public GasAnalyzer gasAnalyzer;
    public GameObject successPanel;

    private bool analyzerUsed = false;
    private bool completed = false;

    void Update()
{
    if (completed) return;

    bool anyBurnerOn = false;
    foreach (var knob in knobs)
    {
        if (knob.IsOn())
        {
            anyBurnerOn = true;
            break;
        }
    }

    if (gasAnalyzer != null && gasAnalyzer.WasUsed())
        analyzerUsed = true;

    if (anyBurnerOn && analyzerUsed)
    {
        completed = true;
        if (successPanel != null)
            successPanel.SetActive(true);
    }
}
}