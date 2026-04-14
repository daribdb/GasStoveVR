using UnityEngine;

public class BurnerKnob : MonoBehaviour
{
    public GameObject flameEffect;
    public float onAngle = 45f;
    private bool isOn = false;

    void Update()
    {
        float angle = transform.localEulerAngles.y;
        if (angle > 180) angle -= 360;

        if (Mathf.Abs(angle) >= onAngle)
            TurnOn();
        else
            TurnOff();
    }

    void TurnOn()
    {
        isOn = true;
        if (flameEffect != null) flameEffect.SetActive(true);
    }

    void TurnOff()
    {
        isOn = false;
        if (flameEffect != null) flameEffect.SetActive(false);
    }

    public bool IsOn() { return isOn; }
}