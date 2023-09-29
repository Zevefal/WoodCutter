using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellWood : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private CoinWallet _coinWallet;

    public void Sell()
    {
        _coinWallet.AddMoney(_inventory.Wood);
        _inventory.TakeWood();
    }
}
