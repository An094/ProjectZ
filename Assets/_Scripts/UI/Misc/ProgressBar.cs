using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float MaxValue;
    private float CurrentValue;
    float LastPercent;
    float CurrentPercent;

    [SerializeField] private Image Mask;

    public void Init(float InMaxValue, float InCurrentValue)
    {
        MaxValue = InMaxValue;
        CurrentValue = InCurrentValue;

        UpdateProgressBar();
    }

    public void SetCurrentValue(float InCurrentValue)
    {
        float LastValue = CurrentValue;
        CurrentValue = InCurrentValue;

        LastPercent = LastValue / MaxValue;
        CurrentPercent = CurrentValue / MaxValue;

        DOVirtual.Float(LastPercent, CurrentPercent, 0.5f, SetProgressValue);

        //UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        float fillAmout = CurrentValue / MaxValue;
        Mask.fillAmount = fillAmout;
    }

    private void SetProgressValue(float InValue)
    {
        Mask.fillAmount = InValue;
    }
}
