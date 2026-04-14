using UnityEngine;
using TMPro;

public class GasAnalyzer : MonoBehaviour
{
    public TextMeshPro displayText;
    public bool hasLeak = false;
    public AudioSource alarmSound;

    private bool isInZone = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GasZone"))
        {
            isInZone = true;
            Invoke("ShowResult", 1.5f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GasZone"))
        {
            isInZone = false;
            CancelInvoke("ShowResult");
            if (displayText != null)
                displayText.text = "---";
        }
    }

    void ShowResult()
    {
        wasUsed = true;
        if (hasLeak)
        {
            if (displayText != null) displayText.text = "УТЕЧКА!";
            if (alarmSound != null) alarmSound.Play();
        }
        else
        {
            if (displayText != null) displayText.text = "НОРМА";
        }
    }
    private bool wasUsed = false;
    public bool WasUsed() { return wasUsed; }
}