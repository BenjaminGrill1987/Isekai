using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    [SerializeField] ItemDatabase _itemDatabase;
    private SpriteRenderer _spriteRenderer;
    public string _comment;

    // Start is called before the first frame update
    void Start()
    {
       // _spriteRenderer = GetComponent<SpriteRenderer>();
       // _spriteRenderer.sprite = _itemDatabase.GetItem(0).GetIcon();
       // _comment = _itemDatabase.GetItem(0).GetDescription();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
