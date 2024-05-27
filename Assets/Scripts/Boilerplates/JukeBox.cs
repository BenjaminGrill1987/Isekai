using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JukeBox : MonoBehaviour
{
    [SerializeField] List<AudioClip> _audioClip;

    private AudioSource _audioSource;
    int _index = 0;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioClip.Count == 0) return;
        _audioSource.clip = _audioClip[_index];
        _audioSource.Play();
    }

    private void FixedUpdate()
    {
        if (_audioClip.Count == 0) return;

        if (!_audioSource.isPlaying)
        {
            ChangeClip();
        }
    }

    private void ChangeClip()
    {
        _index++;
        if(_index  >= _audioClip.Count)
        {
            _index = 0;
        }
        _audioSource.clip = _audioClip[_index];
        _audioSource.Play();
    }
}