using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{
    [SerializeField] private Slider energySlider;
    [SerializeField] private Combatant combatant;

    private void Start()
    {
        energySlider.maxValue = combatant.getEnergy();
    }

    private void Update()
    {
        energySlider.value = combatant.getEnergy();
    }
}
