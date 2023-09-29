using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoodBalance : DisplayBalance
{
    private void Start()
    {
        _text.text = _inventory.Wood.ToString();
    }

    private void OnEnable()
    {
        _inventory.BalanceWoodChanged += OnBalanceChanged;  
    }

    private void OnDisable()
    {
        _inventory.BalanceWoodChanged -= OnBalanceChanged;
    }
}
