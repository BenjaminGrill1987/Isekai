using Isekai.Interface;
using Isekai.Itemsystem;
using Isekai.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Sprite _lookDown, _lookUp, _lookLeft, _lookRight;
    [SerializeField] private LayerMask _layerMask, _attackMask;
    [SerializeField] private GameObject _menu, _spellList, _weapon, _hand;

    private PlayerEquipment _equipment;
    private InputAction _move;
    private Rigidbody2D _rb2D;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _lookDir;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _equipment = GetComponent<PlayerEquipment>();
        _move = InputManager.Input.Player.Movement;
        InputManager.Input.Player.Interact.performed += Interaction;
        InputManager.Input.Player.PlayerMenu.performed += Menu;
        InputManager.Input.Player.Attack.performed += Attack;
        InputManager.Input.Player.Magic.started += MagicMenuOpen;
        InputManager.Input.Player.Magic.canceled += MagicMenuClosed;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        transform.position = MapManager.SetPlayerPos();
        CameraManager.SetPlayer(gameObject);
    }

    private void FixedUpdate()
    {
        if (Gamestate.CurrentState != Gamestates.Play)
        {
            Move(Vector2.zero);
            return;
        }

        Move(_move.ReadValue<Vector2>());
        ChangeSprite();
        ChangeWeaponPos();
    }

    private void Move(Vector3 newVector)
    {
        _rb2D.velocity = newVector * _movementSpeed * Time.deltaTime;
    }

    private void ChangeSprite()
    {
        Vector2 turnDirection = _move.ReadValue<Vector2>();

        if (turnDirection != Vector2.zero)
        {
            _lookDir = turnDirection;
        }

        if (Mathf.Abs(turnDirection.y) > Mathf.Abs(turnDirection.x))
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
        else if (Mathf.Abs(turnDirection.y) < Mathf.Abs(turnDirection.x))
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

    private void ChangeWeaponPos()
    {
        Vector2 turnDirection = _move.ReadValue<Vector2>();

        if (turnDirection != Vector2.zero)
        {
            _lookDir = turnDirection;
        }

        if (Mathf.Abs(turnDirection.y) > Mathf.Abs(turnDirection.x))
        {
            if (turnDirection.y > 0)
            {
                _weapon.transform.localPosition = new Vector2(0, 0.8f);
                _weapon.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                _weapon.transform.localPosition = new Vector2(0, -0.8f);
                _weapon.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
            }
        }
        else if (Mathf.Abs(turnDirection.y) < Mathf.Abs(turnDirection.x))
        {
            if (turnDirection.x > 0)
            {
                _weapon.transform.localPosition = new Vector2(0.65f, -0.221f);
                _weapon.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 270));
            }
            else if (turnDirection.x < 0)
            {
                _weapon.transform.localPosition = new Vector2(-0.65f, 0);
                _weapon.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            }
        }

    }

    public void AddItem(ItemInformation item, int value = 1)
    {
        InventorySystem.AddItem(item, value);
    }

    public void RemoveItem(ItemInformation item, int value = 1)
    {
        InventorySystem.SubtractItem(item, value);
    }

    private void Interaction(InputAction.CallbackContext context)
    {
        if (Gamestate.CurrentState != Gamestates.Play) return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _lookDir, 0.5f, _layerMask);
        if (hit.collider == null) return;

        switch (hit.collider.tag)
        {
            case "BlackBoard":
                {
                    StartCoroutine(WaitFrame(hit));
                    Debug.Log("Finish");
                    break;
                }
            case "NPC":
                {
                    hit.collider.gameObject.GetComponent<NPC>().SpeakWithNPC();
                    Debug.Log("Let me Speak");
                    break;
                }
            default:
                {
                    Debug.LogError("NO VALID COLLIDER");
                    break;
                }
        }

    }

    private void Attack(InputAction.CallbackContext context)
    {
        if (Gamestate.CurrentState != Gamestates.Play) return;
        _weapon.SetActive(true);
    }

    private void Menu(InputAction.CallbackContext context)
    {
        if (Gamestate.CurrentState != Gamestates.Play && Gamestate.CurrentState != Gamestates.PlayerMenu) return;
        _menu.SetActive(!_menu.activeSelf);
    }

    private void MagicMenuOpen(InputAction.CallbackContext context)
    {
        if (Gamestate.CurrentState != Gamestates.Play) return;
        Gamestate.TryToChangeState(Gamestates.Magic);
        _spellList.SetActive(true);
    }

    private void MagicMenuClosed(InputAction.CallbackContext context)
    {
        if (Gamestate.CurrentState != Gamestates.Magic) return;
        Gamestate.TryToChangeState(Gamestates.Play);
        _spellList.SetActive(false);
        _hand.SetActive(false);
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

    private void OnDisable()
    {
        InputManager.Input.Player.Interact.performed -= Interaction;
        InputManager.Input.Player.PlayerMenu.performed -= Menu;
        InputManager.Input.Player.Attack.performed -= Attack;
        InputManager.Input.Player.Magic.started -= MagicMenuOpen;
        InputManager.Input.Player.Magic.canceled -= MagicMenuClosed;
    }

    private void OnGUI()
    {
        float XPos = 60f;
        float YPos = 60f;

        foreach (KeyValuePair<ItemInformation, int> entry in InventorySystem.GetInventory())
        {
            GUI.TextArea(new Rect(XPos, YPos, 100, 100), $"Item: {entry.Key.Name}, Value: {entry.Value}");
            XPos += 10f;
            YPos += 10f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + _lookDir.normalized);
        Gizmos.DrawWireSphere((Vector2)transform.position + _lookDir.normalized, 0.1f);
    }
}