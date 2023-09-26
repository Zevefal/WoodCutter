using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class Player : MonoBehaviour
{
    private const string AttackName = "Attack";
    private const string StaminaName = "Stamina";
    private const int DefaultDamage = 1;
    private const int DefaultStamina = 100;
    private const int DefaultWood = 0;
    private const int DefaultMoney = 0;

    private int _money = 1000;
    private int _stamina;
    private int _maxStamina;
    private int _wood;
    private int _damage = 1;

    public int Damage => _damage;
    public int Stamina => _stamina;
    public int MaxStamina => _maxStamina;
    public int Money => _money;
    public int Wood => _wood;

    public event UnityAction<int, int> StaminaChanged;
    public event UnityAction<int> BalanceWoodChanged;
    public event UnityAction<int> BalanceCoinChanged;
    public event UnityAction NeedSave;

    private void OnEnable()
    {
        if (_stamina > _maxStamina)
        {
            _stamina = _maxStamina;
        }
    }

    public bool TakeHit()
    {
        if (_stamina > 0)
        {
            _stamina--;
            StaminaChanged?.Invoke(_stamina, _maxStamina);
            NeedSave?.Invoke();
            return true;
        }

        return false;
    }

    public void AddMoney(int money)
    {
        _money += money;
        BalanceCoinChanged?.Invoke(_money);
        NeedSave?.Invoke();
    }

    public void AddWood(int wood)
    {
        _wood += wood;
        BalanceWoodChanged?.Invoke(_wood);
        NeedSave?.Invoke();
    }

    public void TakeMoney(int count)
    {
        _money -= count;
        BalanceCoinChanged?.Invoke(_money);
        NeedSave?.Invoke();
    }

    public void TakeWood()
    {
        _wood -= _wood;
        BalanceWoodChanged?.Invoke(_wood);
        NeedSave?.Invoke();
    }

    public void AddStamina(int count)
    {
        _stamina += count;

        if (_stamina >= _maxStamina)
        {
            _stamina = _maxStamina;
        }

        StaminaChanged?.Invoke(_stamina, _maxStamina);
        NeedSave?.Invoke();
    }

    public void PowerUpAttack(int count)
    {
        _damage += count;
    }

    public void PowerUpStamina(int count)
    {
        _maxStamina += count;
        StaminaChanged?.Invoke(_stamina, _maxStamina);
        NeedSave?.Invoke();
    }

    public void PowerUp(string name, int count)
    {
        if (name == AttackName)
        {
            PowerUpAttack(count);
        }
        else if (name == StaminaName)
        {
            PowerUpStamina(count);
        }
    }

    public void InitializePlayerParametrs(int woodCount = DefaultWood, int moneyCount = DefaultMoney, int currentStamina = DefaultStamina, int maxStamina = DefaultStamina, int damage = DefaultDamage)
    {
        _damage = damage;
        _maxStamina = maxStamina;
        _stamina = currentStamina;
        _money = moneyCount;
        _wood = woodCount;
    }
}
