using UnityEngine;
using Isekai.Input;
using UnityEngine.InputSystem;
using Isekai.Interface;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;
using Isekai.Itemsystem;
using Isekai.Utility;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Sprite _lookDown, _lookUp, _lookLeft, _lookRight;
    [SerializeField] private LayerMask _layerMask;

    private Controlls _input;
    private InputAction _move;
    private Rigidbody2D _rb2D;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _lookDir;


    void Awake()
    {
        _input = new Controlls();
        _rb2D = GetComponent<Rigidbody2D>();
        _move = _input.Player.Movement;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Interact.performed += Interaction;
    }

    private void OnDisable()
    {
        _input.Player.Interact.performed -= Interaction;
        _input.Disable();
    }

    private void Start()
    {
        transform.position = MapManager.SetPlayerPos();
    }

    private void FixedUpdate()
    {
        if (Gamestate.CurrentState != Gamestates.Play) return;

        Move(_move.ReadValue<Vector2>());
        ChangeSprite();
    }

    private void Move(Vector3 newVector)
    {
        _rb2D.velocity = newVector * _movementSpeed * Time.deltaTime;
    }

    private void ChangeSprite()
    {
        var turnDirection = _move.ReadValue<Vector2>();

        if (turnDirection != Vector2.zero)
        {
            _lookDir = turnDirection;
        }

        if (turnDirection.Abs().y > turnDirection.Abs().x)
        {
            if (turnDirection.y > 0)
            {
                _spriteRenderer.sprite = _lookUp;
            }
            else
            {
                _spriteRenderer.sprite = _lookDown;
            }
        }
        else if (turnDirection.Abs().y < turnDirection.Abs().x)
        {
            if (turnDirection.x > 0)
            {
                _spriteRenderer.sprite = _lookLeft;
            }
            else if (turnDirection.x < 0)
            {
                _spriteRenderer.sprite = _lookRight;
            }
        }
    }

    public void AddItem(ItemData item, int value = 1)
    {
        InventorySystem.AddItem(item, value);
    }

    public void RemoveItem(ItemData item, int value = 1)
    {
        InventorySystem.SubtractItem(item, value);
    }

    private void Interaction(InputAction.CallbackContext context)
    {
        if (Gamestate.CurrentState != Gamestates.Play) return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _lookDir, 0.5f, _layerMask);
        if (hit.collider == null) return;

        if (hit.collider.isTrigger)
        {
            StartCoroutine(WaitFrame(hit));
            Debug.Log("Finish");
        }
    }

    private IEnumerator WaitFrame(RaycastHit2D newhit)
    {
        var framecount = 1;

        while (framecount > 0)
        {
            framecount--;
            yield return null;
        }
        newhit.collider.TryGetComponent<IInteraction>(out IInteraction interaction);
        interaction.Submit();

    }

    private void OnGUI()
    {
        float XPos = 60f;
        float YPos = 60f;

        foreach (KeyValuePair<ItemData, int> entry in InventorySystem.GetInventory())
        {
            GUI.TextArea(new Rect(XPos, YPos, 100, 100), $"Item: {entry.Key.GetName()}, Value: {entry.Value}");
            XPos += 10f;
            YPos += 10f;
        }
    }
}