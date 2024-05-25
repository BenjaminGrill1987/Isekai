using UnityEngine;

public abstract class Spell : MonoBehaviour , ISpell
{
    [SerializeField] protected int _damage;

    protected Enemy _enemy;

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void SpellHit()
    {
        _enemy.TryGetComponent<IDamageable>(out IDamageable damageAble);
        damageAble.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
