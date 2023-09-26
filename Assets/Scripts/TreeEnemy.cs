using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeEnemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _reward;
    
    private int _health;

    public int Reward => _reward;
    public int Health => _health;

    public event UnityAction<TreeEnemy> Dying;
    public event UnityAction<int> HealthChanged;

    private void Awake()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if(_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
