using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell
{
    [SerializeField] float _minDistance, _movementSpeed;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (ReachedDistance())
        {
            SetHitAnimation();
        }
        else
        {
            GetToTarget();
        }
    }

    private Vector2 Direction()
    {
        return (_enemy.transform.position - gameObject.transform.position);
    }

    private void GetToTarget()
    {
        var move = Direction() * _movementSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + move.x, transform.position.y + move.y);
    }

    private void SetHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }

    private bool ReachedDistance()
    {
        return Vector2.Distance(gameObject.transform.position, _enemy.gameObject.transform.position) < _minDistance;
    }
}