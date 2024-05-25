using Isekai.Input;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellRing : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _circleRadius;
    [SerializeField] List<SpellSettings> _spellSetting;

    List<Vector3> _spellPosition;
    List<GameObject> _spellSymbols;
    Dictionary<GameObject, GameObject> _spells;
    Controlls _input;
    InputAction _inputAction;
    int _index = 0;
    bool _hasRotated = false;

    private void OnEnable()
    {
        _spellSymbols = new List<GameObject>();
        _spellPosition = new List<Vector3>();
        _input = new Controlls();
        _inputAction = _input.UI.Navigate;
        _input.UI.Navigate.performed += RotateRing;
        _input.UI.Submit.started += SelectSpell;
        _input.Enable();

        _index = 0;

        float angle = 0;
        Vector3 offset = Vector3.ProjectOnPlane(Vector3.up, Vector3.forward) * _circleRadius;

        for (int i = 0; i < _spellSetting.Count; i++)
        {
            Vector3 rotation = Quaternion.AngleAxis(angle, Vector3.forward) * offset;

            var symbol = Instantiate(_spellSetting[i].SpellUI, new Vector2(rotation.x, rotation.y), Quaternion.identity);
            symbol.transform.SetParent(transform, false);
            _spellSymbols.Add(symbol);
            _spellPosition.Add(symbol.transform.position);
            angle += 360f / _spellSetting.Count;
        }
    }

    private void RotateRing(InputAction.CallbackContext context)
    {
        Debug.Log(_input.UI.Navigate.ReadValue<Vector2>().x);

        if (_inputAction.ReadValue<Vector2>().x < 0 && _spellSetting.Count > 1 && !_hasRotated)
        {
            _index++;
            Debug.Log($"Index: {_index}");
            if (_index >= _spellSetting.Count) _index = 0;

            foreach (var symbol in _spellSymbols)
            {
                symbol.transform.position = _spellPosition[_index];
                _index++;
                if (_index >= _spellSetting.Count) _index = 0;
            }
            _hasRotated = true;
            Debug.Log($"Index: {_index}");
        }
        else if (_inputAction.ReadValue<Vector2>().x > 0 && _spellSetting.Count > 1 && !_hasRotated)
        {
            _index--;
            Debug.Log($"Index: {_index}");
            if (_index < 0) _index = _spellSetting.Count - 1;

            foreach (var symbol in _spellSymbols)
            {
                symbol.transform.position = _spellPosition[_index];
                _index--;
                if (_index < 0) _index = _spellSetting.Count - 1;
            }
            _hasRotated = true;
            Debug.Log($"Index: {_index}");
        }

        if (_inputAction.ReadValue<Vector2>().x == 0) _hasRotated = false;
    }

    private void SelectSpell(InputAction.CallbackContext context)
    {
        if (EnemyList.Enemies.Count == 0) return;
        EnemyList.Enemies[0].SpellHit(true);
        var spell = Instantiate(_spellSetting[_index].Spell, _player.position, Quaternion.identity);
        spell.GetComponent<Spell>().SetEnemy(EnemyList.Enemies[0]);
        OnDisable();
    }

    private void OnDisable()
    {
        _input.Disable();
        foreach (GameObject symbol in _spellSymbols)
        {
            Destroy(symbol);
        }
    }
}