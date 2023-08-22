using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider slider;

    public Color32 greenColor;
    public Color32 redColor;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        this.GetComponentInChildren<Image>().color = greenColor;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        if (slider.value <= slider.maxValue / 3)
        {
            this.GetComponentInChildren<Image>().color = redColor;
        }
        else
        {
            this.GetComponentInChildren<Image>().color = greenColor;
        }
    }
}
