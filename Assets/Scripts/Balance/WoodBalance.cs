using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoodBalance : Balance
{
    private void Start()
    {
        _text.text = _player.Wood.ToString();
    }

    private void OnEnable()
    {
        _player.BalanceWoodChanged += OnBalanceChanged;  
    }

    private void OnDisable()
    {
        _player.BalanceWoodChanged -= OnBalanceChanged;
    }
}
