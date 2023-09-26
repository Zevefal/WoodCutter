using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : Bar
{
    [SerializeField] private Player _player;

    private void Start()
    {
        _text.text = ($"{_player.Stamina.ToString()}/{_player.MaxStamina.ToString()}");
        OnValueChanged(_player.Stamina, _player.MaxStamina);
    }

    private void OnEnable()
    {
        _player.StaminaChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.StaminaChanged -= OnValueChanged;
    }
}
