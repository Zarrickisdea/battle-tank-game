using UnityEngine;
using UnityEngine.UI;

public class FillValueNumber : MonoBehaviour
{
    [SerializeField] private Image TargetImage;
    private float MaxValue;
    private float Value;
    void Update()
    {
        float currentValue = Value / MaxValue;
        TargetImage.fillAmount = currentValue;
        gameObject.GetComponent<Text>().text = Value.ToString("F0");
    }

    public void Initialize(float maxValue)
    {
        MaxValue = maxValue;
        Value = maxValue;
    }

    public void UpdateValue(float incValue)
    {
        Value = incValue;
    }
}
