using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellSetting", menuName = "Spell/Spell Setting", order = 0)]
public class SpellSettings : ScriptableObject
{
    [SerializeField] string _spellName;
    [SerializeField] GameObject _spell, _spellUI;
    [SerializeField] int _damage;

    public GameObject Spell => _spell;
    public GameObject SpellUI => _spellUI;
}
