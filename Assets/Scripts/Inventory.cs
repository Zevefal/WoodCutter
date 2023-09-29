using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    private int _wood;
    
    public int Wood => _wood;

    public event UnityAction<int> BalanceWoodChanged;

    public void AddWood(int wood)
    {
        _wood += wood;
        BalanceWoodChanged?.Invoke(_wood);
    }

    public void TakeWood()
    {
        _wood -= _wood;
        BalanceWoodChanged?.Invoke(_wood);
    }
}
