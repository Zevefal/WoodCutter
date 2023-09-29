using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBalance : DisplayBalance
{
    private void Start()
    {
        _text.text = _coinWallet.Money.ToString();
    }

    private void OnEnable()
    {
        _coinWallet.BalanceCoinChanged += OnBalanceChanged;
    }

    private void OnDisable()
    {
        _coinWallet.BalanceCoinChanged -= OnBalanceChanged;
    }
}
