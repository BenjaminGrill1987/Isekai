using UnityEngine;

namespace Isekai.Itemsystem
{

    public class Item : MonoBehaviour
    {
        [SerializeField] private int _itemId;
        private SpriteRenderer _spriteRenderer;

        void Start()
        {
            Debug.Log("Start");
            Init();
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

        public void SetID(int newID)
        {
            Debug.Log("SetID");
            _itemId = newID;
        }

        private void Init()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = ItemDatabase.GetItem(_itemId).GetIcon();
            GetComponent<BoxCollider2D>().size = _spriteRenderer.size;
        }
    }
}