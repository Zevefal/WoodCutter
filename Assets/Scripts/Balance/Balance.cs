using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Balance : MonoBehaviour
{
    [SerializeField] protected TMP_Text _text;
    [SerializeField] protected Player _player;

    public void OnBalanceChanged(int balance)
    {
        _text.text = balance.ToString();
    }
}
