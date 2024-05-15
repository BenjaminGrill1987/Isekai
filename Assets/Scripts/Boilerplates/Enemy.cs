using Isekai.Itemsystem;
using System;
using UnityEditor;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health, _damage, _itemDrop;
    [SerializeField] private float _circleRange, _rangeToTarget, _moveSpeed;
    [SerializeField] private GameObject _item;

    Vector2 _moveCircleMiddlePoint, _targetToMove;

    public Rigidbody2D _rigidBody2D;

    public Vector2 MoveCircleMiddlePoint => _moveCircleMiddlePoint;
    public Vector2 TargetToMove => _targetToMove;
    public float CircleRange => _circleRange;
    public float RangeToTarget => _rangeToTarget;
    public float MoveSpeed => _moveSpeed;

    public virtual void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _moveCircleMiddlePoint = transform.position;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        var item = Instantiate(_item, transform.position, Quaternion.identity);
        item.GetComponent<Item>().SetID(_itemDrop);
        Destroy(gameObject);
    }

    public void SetTargetToMove(Vector2 newTarget)
    {
        _targetToMove = newTarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_moveCircleMiddlePoint == Vector2.zero ? transform.position : _moveCircleMiddlePoint, _circleRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_targetToMove == Vector2.zero ? transform.position : _targetToMove, _rangeToTarget);
    }
}