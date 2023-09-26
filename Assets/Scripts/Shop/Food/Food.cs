using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _staminaRecoveryCount;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _cost;

    public string Name => _name;
    public int StaminaRecoveryCount => _staminaRecoveryCount;
    public int Cost => _cost;
    public Sprite Icon => _icon;
}
