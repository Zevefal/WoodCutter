using System;
using UnityEngine;
using UnityEngine.Events;

public class CoinWallet : MonoBehaviour
{
    [SerializeField] private Player _player;
    private int _money;

    public int Money => _money;

    public event UnityAction<int> BalanceCoinChanged;

    public void AddMoney(int money)
    {
        _money += money;
        BalanceCoinChanged?.Invoke(_money);
    }

    public void TakeMoney(int count)
    {
        _money -= count;
        BalanceCoinChanged?.Invoke(_money);
    }
}
