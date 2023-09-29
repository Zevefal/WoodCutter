using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private const string PathName = "/save.dat";

    [SerializeField] private Player _player;
    [SerializeField] private CoinWallet _coinWallet;
    [SerializeField] private Inventory _inventory;

    private void OnEnable()
    {
        Load();
        _player.NeedSave += Save;
    }

    private void OnDisable()
    {
        _player.NeedSave -= Save;
    }

    private void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + PathName);
        SaveData data = new SaveData();

        data.SaveParametrs(_inventory.Wood,_coinWallet.Money,_player.Stamina,_player.MaxStamina,_player.Damage,DateTime.UtcNow);
        formatter.Serialize(file, data);
        file.Close();
    }

    private void Load()
    {
        if (File.Exists((Application.persistentDataPath + PathName)))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + PathName, FileMode.Open);
            SaveData data = (SaveData)formatter.Deserialize(file);
            file.Close();

            TimeSpan timePassed = DateTime.UtcNow - data.DateTime;
            int minutsPassed = (int)timePassed.TotalMinutes;
            int staminaCount = Mathf.Clamp(minutsPassed, 0, 7 * 24 * 60);
            staminaCount += minutsPassed;
            int totalStamina = staminaCount + data.CurrentStamina;

            _player.InitializePlayerParametrs(/*data.WoodCount, data.MoneyCount, */totalStamina, data.MaxStaminaCount, data.DamageCount);
            _coinWallet.AddMoney(data.MoneyCount);
            _inventory.AddWood(data.WoodCount);
        }
        else
        {
            _player.InitializePlayerParametrs();
        }
    }

    private void ResetData()
    {
        if (File.Exists((Application.persistentDataPath + PathName)))
        {
            File.Delete(Application.persistentDataPath + PathName);
            PlayerPrefs.DeleteAll();
        }
    }
}

[Serializable]
class SaveData
{
    private int _woodCount;
    private int _moneyCount;
    private int _currentStamina;
    private int _maxStaminaCount;
    private int _damageCount;
    private DateTime _dateTime;

    public int WoodCount => _woodCount;
    public int MoneyCount => _moneyCount;
    public int CurrentStamina => _currentStamina;
    public int MaxStaminaCount => _maxStaminaCount;
    public int DamageCount => _damageCount;
    public DateTime DateTime => _dateTime;

    public void SaveParametrs(int WoodCount, int MoneyCount, int CurrentStamina, int MaxStamina, int DamageCount, DateTime Date)
    {
        _woodCount = WoodCount;
        _moneyCount = MoneyCount;
        _currentStamina = CurrentStamina;
        _maxStaminaCount = MaxStamina;
        _damageCount = DamageCount;
        _dateTime = Date;
    }
}
