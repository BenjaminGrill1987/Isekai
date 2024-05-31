using Isekai.Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellTargetSelector : MonoBehaviour
{
    Vector2 _playerPos;
    GameObject _spell;
    InputAction _inputAction;
    int _enemyIndex = 0;
    bool _hasRotated = false;


    private void FixedUpdate()
    {
        transform.position = EnemyList.Enemies[_enemyIndex].transform.position;
    }

    public void GetSpell(GameObject newSpell, Vector2 newPlayerPos)
    {
        _spell = newSpell;
        _playerPos = newPlayerPos;

        InputManager.Input.SpellTarget.Navigate.performed += ChooseEnemy;
        InputManager.Input.SpellTarget.Submit.started += CastSpell;
        _inputAction = InputManager.Input.SpellTarget.Navigate;
    }

    private void ChooseEnemy(InputAction.CallbackContext context)
    {
        Debug.Log("Choose");
        if (_inputAction.ReadValue<Vector2>().x < 0 && EnemyList.Enemies.Count > 1 && !_hasRotated)
        {
            _enemyIndex++;
            if (_enemyIndex >= EnemyList.Enemies.Count) _enemyIndex = 0;

            foreach (var enemy in EnemyList.Enemies)
            {
                _enemyIndex++;
                if (_enemyIndex >= EnemyList.Enemies.Count) _enemyIndex = 0;
            }
            _hasRotated = true;
        }
        else if (_inputAction.ReadValue<Vector2>().x > 0 && EnemyList.Enemies.Count > 1 && !_hasRotated)
        {
            _enemyIndex--;
            if (_enemyIndex < 0) _enemyIndex = EnemyList.Enemies.Count - 1;

            foreach (var enemy in EnemyList.Enemies)
            {
                _enemyIndex--;
                if (_enemyIndex < 0) _enemyIndex = EnemyList.Enemies.Count - 1;
            }
            _hasRotated = true;
        }

        if (_inputAction.ReadValue<Vector2>().x == 0) _hasRotated = false;
    }

    private void CastSpell(InputAction.CallbackContext context)
    {
        Debug.Log("cast");
        EnemyList.Enemies[_enemyIndex].SpellHit(true);
        var spell = Instantiate(_spell, _playerPos, Quaternion.identity);
        spell.GetComponent<Spell>().SetEnemy(EnemyList.Enemies[_enemyIndex]);
        OnDisable();
    }

    private void OnDisable()
    {
        InputManager.Input.SpellTarget.Navigate.performed -= ChooseEnemy;
        InputManager.Input.SpellTarget.Submit.started -= CastSpell;

        _enemyIndex = 0;
        gameObject.SetActive(false);
    }
}
