using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpell : Spell
{
    private void FixedUpdate()
    {
        transform.position = _enemy.transform.position;
    }
}
