using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider defenceSlider;
    [SerializeField] private Combatant combatant;

    private void Start()
    {
        healthSlider.maxValue = combatant.getHealth();
        defenceSlider.maxValue = combatant.getHealth();
    }

    private void Update()
    {
        healthSlider.value = combatant.getHealth();
        defenceSlider.value = combatant.getDefence();

        if(combatant.CompareTag("dead")){
            gameObject.SetActive(false);
        }

    }

}
