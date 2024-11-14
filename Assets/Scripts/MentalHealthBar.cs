using UnityEngine;
using UnityEngine.UI;

public class MentalHealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.minValue = 0;
        slider.maxValue = health;
    }

    public int GetMaxHealth() => (int)slider.maxValue;

    public void SetHealth(int health) => slider.value = health;
}
