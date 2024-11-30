using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        slider.maxValue = playerController.getHealth();
    }

    private void Update()
    {
        slider.value = playerController.getHealth();
    }
}
