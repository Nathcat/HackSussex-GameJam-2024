using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour
{

    public Slider slider;

    void ChangeMaxEnergy(int energy){
            slider.maxValue = energy;
            slider.value = energy;
    }

    void SetMaxEnergy(){
        slider.value = slider.maxValue;
    }

    void SetEnergy(int energy)
    {
        slider.value = energy;
    }

}
