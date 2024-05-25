using Isekai.Interface;
using Isekai.Itemsystem;
using Isekai.Utility;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health, _damage, _itemDrop;
    [SerializeField] private float _circleRange, _rangeToTarget, _moveSpeed;
    [SerializeField] private GameObject _item;

    Vector2 _moveCircleMiddlePoint, _targetToMove, _oldPosition;
    Timer _timer;
    bool _isNotMoving = false, _isCheckedIn = false, _spellIsHit = false;
    Renderer _renderer;


    public Rigidbody2D _rigidBody2D;

    public Vector2 MoveCircleMiddlePoint => _moveCircleMiddlePoint;
    public Vector2 TargetToMove => _targetToMove;
    public float CircleRange => _circleRange;
    public float RangeToTarget => _rangeToTarget;
    public float MoveSpeed => _moveSpeed;
    public bool _IsNotMoving => _isNotMoving;
    public bool SpellIsHit => _spellIsHit;

    public virtual void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _moveCircleMiddlePoint = transform.position;
        _oldPosition = transform.position;
        _timer = new Timer(1,NotMoving);
        _renderer = GetComponent<Renderer>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Death();
        }
        SpellHit(false);
    }

    public void Death()
    {
        var item = Instantiate(_item, transform.position, Quaternion.identity);
        item.GetComponent<Item>().SetID(_itemDrop);
        Destroy(gameObject);
    }

    public virtual void FixedUpdate()
    {
        if (Gamestate.CurrentState != Gamestates.Play || _spellIsHit == true) return;

        var speed = Vector2.Distance(_oldPosition, transform.position);
        if(_isNotMoving)
        {
            _isNotMoving = false;
        }
        if(speed <= 0)
        {
          _timer.Tick();
        }
        
        if(_renderer.isVisible && !_isCheckedIn)
        {
            CheckIn();
        }
        else if(!_renderer.isVisible && _isCheckedIn)
        {
            Checkout();
        }

        _oldPosition = transform.position;
    }

    private void CheckIn()
    {
        EnemyList.AddEnemy(this);
        _isCheckedIn = true;
    }

    private void Checkout()
    {
        EnemyList.RemoveEnemy(this);
        _isCheckedIn = false;
    }

    public void SetTargetToMove(Vector2 newTarget)
    {
        _targetToMove = newTarget;
    }

    public void SpellHit(bool newBool)
    {
        _spellIsHit = newBool;
    }

    private void NotMoving()
    {
        _isNotMoving = true;
    }

    private void OnDisable()
    {
        EnemyList.RemoveEnemy(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_moveCircleMiddlePoint == Vector2.zero ? transform.position : _moveCircleMiddlePoint, _circleRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_targetToMove == Vector2.zero ? transform.position : _targetToMove, _rangeToTarget);
    }
}