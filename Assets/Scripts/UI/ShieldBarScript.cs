using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarScript : MonoBehaviour
{

    public Slider slider;

    void ChangeMaxShield(int shield){
            slider.maxValue = shield;

    }

    void SetMaxShield(){
        slider.value = slider.maxValue;
    }

    void SetShield(int shield)
    {
        slider.value = shield;
    }

}
