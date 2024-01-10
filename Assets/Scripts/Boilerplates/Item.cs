using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _itemId;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = ItemDatabase.GetItem(_itemId).GetIcon();
        GetComponent<BoxCollider2D>().size = _spriteRenderer.size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect(collision);
    }

    public void Collect(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        collision.GetComponent<PlayerController>().AddItem(ItemDatabase.GetItem(_itemId));
        Destroy(gameObject);
    }
}