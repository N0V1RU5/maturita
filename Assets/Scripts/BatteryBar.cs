using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPerc(float perc)
    {
        slider.maxValue = perc;
        slider.value = perc;
    }

    public void SetPerc(float perc)
    {
        slider.value = perc;
    }

    public void kys()
    {
        slider.value = 1;
    }
}
