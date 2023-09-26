using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeHPDraw : MonoBehaviour
{
    [SerializeField] private TMP_Text _treeHPText;

    private TreeEnemy _tree;

    public void InitializeTree(TreeEnemy tree)
    {
        _tree = tree;
        _tree.HealthChanged += OnTreeHealthChanged;
        OnTreeHealthChanged(_tree.Health);
    }

    private void OnDisable()
    {
        _tree.HealthChanged -= OnTreeHealthChanged;
    }

    private void OnTreeHealthChanged(int health)
    {
        _treeHPText.text = ("Thee hp: "+ health.ToString());
    }
}
