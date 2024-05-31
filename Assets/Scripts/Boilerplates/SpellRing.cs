using Isekai.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellRing : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _circleRadius;
    [SerializeField] List<SpellSettings> _spellSetting;
    [SerializeField] GameObject _hand;

    List<Vector3> _spellPosition;
    List<GameObject> _spellSymbols;
    InputAction _inputAction;
    int _index = 0;
    bool _hasRotated = false;

    private void OnEnable()
    {
        _spellSymbols = new List<GameObject>();
        _spellPosition = new List<Vector3>();
        _inputAction = InputManager.Input.MagicRing.Navigate;
        InputManager.Input.MagicRing.Navigate.performed += RotateRing;
        InputManager.Input.MagicRing.Submit.started += SelectSpell;

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
        if (_spellSymbols.Count == 0) return;

        Debug.Log(_spellSymbols.Count);

        if (_inputAction.ReadValue<Vector2>().x < 0 && _spellSetting.Count > 1 && !_hasRotated)
        {
            _index++;
            if (_index >= _spellSetting.Count) _index = 0;

            foreach (var symbol in _spellSymbols)
            {
                symbol.transform.position = _spellPosition[_index];
                _index++;
                if (_index >= _spellSetting.Count) _index = 0;
            }
            _hasRotated = true;
        }
        else if (_inputAction.ReadValue<Vector2>().x > 0 && _spellSetting.Count > 1 && !_hasRotated)
        {
            _index--;
            if (_index < 0) _index = _spellSetting.Count - 1;

            foreach (var symbol in _spellSymbols)
            {
                symbol.transform.position = _spellPosition[_index];
                _index--;
                if (_index < 0) _index = _spellSetting.Count - 1;
            }
            _hasRotated = true;
        }

        if (_inputAction.ReadValue<Vector2>().x == 0) _hasRotated = false;
    }

    private void SelectSpell(InputAction.CallbackContext context)
    {
        if (EnemyList.Enemies.Count == 0 || _spellSymbols.Count == 0) return;
        OnDisable();
        StartCoroutine(WaitFrame());
    }

    private void CloseSpellRing()
    {
        _hand.SetActive(true);
        Debug.Log("Active");
        _hand.transform.position = EnemyList.Enemies[0].transform.position;
        _hand.GetComponent<SpellTargetSelector>().GetSpell(_spellSetting[_index].Spell, _player.transform.position);
    }

    private void SpellringDestroy()
    {
        foreach (GameObject symbol in _spellSymbols)
        {
            Destroy(symbol);
        }
        _spellSymbols.Clear();
        InputManager.Input.MagicRing.Navigate.performed -= RotateRing;
        InputManager.Input.MagicRing.Submit.started -= SelectSpell;
    }

    private IEnumerator WaitFrame()
    {
        var framecount = 1;

        while (framecount > 0)
        {
            framecount--;
            yield return null;
        }
        CloseSpellRing();
    }

    private void OnDisable()
    {
        SpellringDestroy();
    }
}