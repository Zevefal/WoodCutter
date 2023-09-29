using TMPro;
using UnityEngine;

public abstract class DisplayBalance : MonoBehaviour
{
    [SerializeField] protected TMP_Text _text;
    [SerializeField] protected CoinWallet _coinWallet;
    [SerializeField] protected Inventory _inventory;

    public void OnBalanceChanged(int balance)
    {
        _text.text = balance.ToString();
    }
}
