using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Image _bar;
    [SerializeField] protected TMP_Text _text;

    public void OnValueChanged(int value, int maxValue)
    {
        _bar.fillAmount = (float)value/maxValue;
        _text.text = ($"{value.ToString()}/{maxValue.ToString()}");
    }
}
