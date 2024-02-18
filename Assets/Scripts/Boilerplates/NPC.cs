using Isekai.Interface;
using Isekai.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    [SerializeField] protected Sprite _face;
    [SerializeField] protected string _name;
    [SerializeField] protected string[] _texts;
    [SerializeField] protected GameObject _spechBoard;

    public void SpeakWithNPC()
    {
        Gamestate.TryToChangeState(Gamestates.NPCSpeaking);
        _spechBoard.SetActive(true);
        _spechBoard.GetComponent<SpechBubble>().Init(_name, _texts[0],_face);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, (Vector2)transform.position + _lookDir.normalized);
    //    Gizmos.DrawWireSphere((Vector2)transform.position + _lookDir.normalized, 0.1f);
    //}

}
