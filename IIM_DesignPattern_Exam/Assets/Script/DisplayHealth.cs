using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] PlayerEntity _player;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Slider _slider;

    void UpdateDisplayedHealth(int _) => 
        _text.text = _player.Health.CurrentHealth.ToString();

    void UpdateDisplayedHealthSlider(int _) =>
        _slider.value = (float)((float)((_ - 0) / (1 - 0)) * 0.1);


    private void Start()
    {
        UpdateDisplayedHealth(_player.Health.CurrentHealth);

        // Inscription
        _player.Health.OnDamage += UpdateDisplayedHealth;
        _player.Health.OnDamage += UpdateDisplayedHealthSlider;

        _player.Health.OnHeal += UpdateDisplayedHealth;
        _player.Health.OnHeal += UpdateDisplayedHealthSlider;
    }

    private void OnDestroy()
    {
        // Désinscription
        _player.Health.OnDamage -= UpdateDisplayedHealth;
        _player.Health.OnDamage -= UpdateDisplayedHealthSlider;

        _player.Health.OnHeal -= UpdateDisplayedHealthSlider;
        _player.Health.OnHeal -= UpdateDisplayedHealth;

    }

    /*private void _player_OnHealthChanged(int obj)
    {
        UpdateDisplayedHealth(obj);
        UpdateDisplayedHealthSlider(obj);
    }*/
}
