using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class StaminaRestore : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private Player _player;

    private float _currentTime = 60f;
    private float _waitTime = 60f;
    private int _staminaRestoreCount = 1;

    private void Start()
    {
        StartCoroutine(StaminaTimer());
    }

    private IEnumerator StaminaTimer()
    {
        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                _currentTime = _waitTime;
                _player.AddStamina(_staminaRestoreCount);
            }

            yield return null;
            RefreshTimeText();
        }
    }

    private void RefreshTimeText()
    {
        float minutes = Mathf.FloorToInt(_currentTime / 60);
        float seconds = Mathf.FloorToInt(_currentTime % 60);

        _timeText.text = minutes + ":" + seconds;
    }
}
