using Isekai.Input;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SpellRing : MonoBehaviour
{
    [SerializeField] float _circleRadius;
    [SerializeField] List<GameObject> _spellSymbol;

    List<Vector3> _spellPosition;
    List<GameObject> _spellSymbols;
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
        _input.Enable();

        _index = 0;

        float angle = 0;
        Vector3 offset = Vector3.ProjectOnPlane(Vector3.up, Vector3.forward) * _circleRadius;

        for (int i = 0; i < _spellSymbol.Count; i++)
        {
            Vector3 rotation = Quaternion.AngleAxis(angle, Vector3.forward) * offset;

            var symbol = Instantiate(_spellSymbol[i], new Vector2(rotation.x, rotation.y), Quaternion.identity);
            symbol.transform.SetParent(transform, false);
            _spellSymbols.Add(symbol);
            _spellPosition.Add(symbol.transform.position);
            angle += 360f / _spellSymbol.Count;
        }
    }

    private void RotateRing(InputAction.CallbackContext context)
    {
        Debug.Log(_input.UI.Navigate.ReadValue<Vector2>().x);

        if (_inputAction.ReadValue<Vector2>().x < 0 && _spellSymbol.Count > 1 && !_hasRotated)
        {
            _index++;
            Debug.Log($"Index: {_index}");
            if (_index >= _spellSymbol.Count) _index = 0;

            foreach (var symbol in _spellSymbols)
            {
                symbol.transform.position = _spellPosition[_index];
                _index++;
                if (_index >= _spellSymbol.Count) _index = 0;
            }
            _hasRotated = true;
            Debug.Log($"Index: {_index}");
        }
        else if (_inputAction.ReadValue<Vector2>().x > 0 && _spellSymbol.Count > 1 && !_hasRotated)
        {
            _index--;
            Debug.Log($"Index: {_index}");
            if (_index < 0) _index = _spellSymbol.Count - 1;

            foreach (var symbol in _spellSymbols)
            {
                symbol.transform.position = _spellPosition[_index];
                _index--;
                if (_index < 0) _index = _spellSymbol.Count - 1;
            }
            _hasRotated = true;
            Debug.Log($"Index: {_index}");
        }

        if (_inputAction.ReadValue<Vector2>().x == 0) _hasRotated = false;
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