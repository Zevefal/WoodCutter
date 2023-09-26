using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellWood : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Sell()
    {
        _player.AddMoney(_player.Wood);
        _player.TakeWood();
    }
}
