using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.TryGetComponent<IDamageable>(out IDamageable damageable);
            damageable.TakeDamage(_damage);
        }
    }

    private void DeactivateWeapon()
    {
        gameObject.SetActive(false);
    }
}
