using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<TreeEnemy> _trees;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private TreeHPDraw _treeHPDraw;

    private void Awake()
    {
        InstantiateTrees();
    }

    private void InstantiateTrees()
    {
        TreeEnemy tree = Instantiate(_trees[Random.Range(0, _trees.Count)], _spawnPosition.position,_spawnPosition.rotation,_spawnPosition);
        tree.GetComponent<ClickOnTreeTrack>().InitializePlayer(_player);
        tree.Dying += OnTreeDying;
        _treeHPDraw.InitializeTree(tree);
    }

    private void OnTreeDying(TreeEnemy tree)
    {
        tree.Dying -= OnTreeDying;
        _inventory.AddWood(tree.Reward);

        InstantiateTrees();
    }
}
