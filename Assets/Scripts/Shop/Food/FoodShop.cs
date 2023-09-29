using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShop : MonoBehaviour
{
    [SerializeField] private List<Food> _foods;
    [SerializeField] private Player _player;
    [SerializeField] private CoinWallet _coinWallet;
    [SerializeField] private FoodView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for(int i = 0; i < _foods.Count; i++)
        {
            AddItem(_foods[i]);
        }
    }

    private void AddItem(Food food)
    {
        var view = Instantiate(_template, _itemContainer.transform);

        view.Render(food, _player, _coinWallet);
    }
}
