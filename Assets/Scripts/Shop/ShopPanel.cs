using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private List<ShopButtonClick> _shopButtons;

    private void OnEnable()
    {
        for (int i = 0; i < _shopButtons.Count; i++)
        {
            _shopButtons[i].IsClicked += ActivateScrollView;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _shopButtons.Count; i++)
        {
            _shopButtons[i].IsClicked -= ActivateScrollView;
        }
    }

    public void ActivateScrollView(ShopButtonClick buttonClicked)
    {
        for (int i = 0; i < _shopButtons.Count; i++)
        {
            _shopButtons[i].SetScrollViewActive(false);
        }

        buttonClicked.SetScrollViewActive(true);
    }

    public void OpenShop()
    {
        _shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        _shopPanel.SetActive(false);
    }
}
