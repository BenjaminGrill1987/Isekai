using System;
using System.Collections.Generic;
using UnityEngine;


public class GridAnimation : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private float _animationTime;

    private Timer _timer;
    private SpriteRenderer _spriteRenderer;
    private int _index = 0;

    public List<Sprite> _Sprites { get => _sprites; }
    public float _AnimationTime { get => _animationTime; }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _timer = new Timer(_animationTime, () => ChangeSprite());
    }

    void LateUpdate()
    {
        _timer.Tick();

        if(_animationTime != _timer.StartTime)
        {
            UpdateTimer();
        }
    }

    private void ChangeSprite()
    {
        _index++;
        if (_index == _sprites.Count)
        {
            _index = 0;
        }

        _spriteRenderer.sprite = _sprites[_index];
    }

    private void UpdateTimer()
    {
        _timer.TimerUpdate(_animationTime);
    }
}