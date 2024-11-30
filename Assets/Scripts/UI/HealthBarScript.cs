using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;

    void ChangeMaxHealth(int health){
            slider.maxValue = health;

    }

    void SetMaxHealth(){
        slider.value = slider.maxValue;
    }

    void SetHealth(int health)
    {
        slider.value = health;
    }

}
