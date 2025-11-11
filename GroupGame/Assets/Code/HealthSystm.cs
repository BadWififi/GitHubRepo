using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystm : MonoBehaviour
{

    public Slider Slider;


    public void SetMaxHealth(int Health)
    {
        Slider.maxValue = Health;
        Slider.value = Health;
    }
    
    public void SetHealth(int health)
    {
        Slider.value = health;
    }


}
