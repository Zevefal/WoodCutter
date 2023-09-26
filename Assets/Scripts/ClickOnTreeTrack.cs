using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TreeEnemy))]
[RequireComponent(typeof(Animator))]
public class ClickOnTreeTrack : MonoBehaviour, IPointerDownHandler
{
    private const string HitAnimationName = "Hit";

    private Player _player;
    private TreeEnemy _tree;
    private Animator _animator;

    public static event UnityAction isClickedOnTree;

    private void Start()
    {
        _tree = gameObject.GetComponent<TreeEnemy>();
        _animator = gameObject.GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_player.TakeHit() == true)
        {
            _tree.TakeDamage(_player.Damage);
            _animator.SetTrigger(HitAnimationName);
            isClickedOnTree?.Invoke();
        }
    }

    public void InitializePlayer(Player player)
    {
        _player = player;
    }
}
