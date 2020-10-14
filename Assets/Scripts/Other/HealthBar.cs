using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public Slider slider;
    public Text text;

    private Health health;

    void Start()
    {
        health = player.GetComponent<Health>();

        slider.minValue = 0;
        slider.maxValue = health.MaxHealth;

        slider.value = health.MaxHealth;

        text.text = $"{slider.value} / {slider.maxValue}";

        health.OnHealthChanged += value =>
        {
            slider.value = value;
            text.text = $"{slider.value} / {slider.maxValue}";
        };
    }
}