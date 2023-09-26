using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuyPowerUps : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _initialCost;
    [SerializeField] private float _progression;
    [SerializeField] private int _maxPowerCount;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _powerUpButtonNameText;
    [SerializeField] private TMP_Text _costText;

    private int _powerCount = 1;
    private int _currentCost;
    private int _addPowerCount = 1;

    private void OnEnable()
    {
        _powerUpButtonNameText.text = ($"Player {_name} + {_addPowerCount}");

        SetCost();
    }

    public void Upgrade()
    {
        _powerCount = PlayerPrefs.GetInt(_name);

        if (_powerCount < _maxPowerCount && _player.Money >= _currentCost)
        {
            PlayerPrefs.SetInt(_name, _powerCount + _addPowerCount);
            _player.PowerUp(_name, _addPowerCount);
            _player.TakeMoney(_currentCost);
            SetCost();
        }
    }

    private void SetCost()
    {
        if (PlayerPrefs.HasKey(_name))
        {
            _powerCount = PlayerPrefs.GetInt(_name);
            _currentCost = Mathf.RoundToInt(_initialCost * Mathf.Pow(_progression, _powerCount - 1));
            _costText.text = _currentCost.ToString();
        }
        else
        {
            PlayerPrefs.SetInt(_name, _powerCount);
            SetCost();
        }
    }
}
