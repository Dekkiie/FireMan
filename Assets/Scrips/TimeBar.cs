using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    public void SetHealthh(float health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(float health)
    {
        slider.value = health;
    }
}
