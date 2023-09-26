using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _hitClips; 

    private void OnEnable()
    {
        ClickOnTreeTrack.isClickedOnTree += PlayHitSound;
    }

    private void OnDisable()
    {
        ClickOnTreeTrack.isClickedOnTree -= PlayHitSound;
    }

    private void PlayHitSound()
    {
        _audioSource.clip = _hitClips[Random.Range(0,_hitClips.Count)];
        _audioSource.Play();
    }
}
