using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FoodView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private int _staminaCount;
    private int _cost;
    private Player _player;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Food food, Player player)
    {
        _player = player;

        _staminaCount = food.StaminaRecoveryCount;
        _nameText.text = food.Name + $" adds {_staminaCount.ToString()} stamina";
        _cost = food.Cost;
        _costText.text = "Cost: " + _cost.ToString();
        _icon.sprite = food.Icon;
    }

    private void OnButtonClick()
    {
        if (_player.Money >= _cost)
        {
            _player.TakeMoney(_cost);
            _player.AddStamina(_staminaCount);
        }
    }
}
