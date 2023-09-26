using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopButtonClick : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _scrollView;

    public event UnityAction<ShopButtonClick> IsClicked;

    private void OnEnable()
    {
        _button.onClick?.AddListener(OnClick); 
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        IsClicked?.Invoke(this);
    }

    public void SetScrollViewActive(bool activity) 
    {
        _scrollView.SetActive(activity);
    }
}
