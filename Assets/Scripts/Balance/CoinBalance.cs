using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBalance : Balance
{
    private void Start()
    {
        _text.text = _player.Money.ToString();
    }

    private void OnEnable()
    {
        _player.BalanceCoinChanged += OnBalanceChanged;
    }

    private void OnDisable()
    {
        _player.BalanceCoinChanged -= OnBalanceChanged;
    }
}
