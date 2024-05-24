using Isekai.Interface;
using Isekai.Utility;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OnClickStart()
    {
        Gamestate.TryToChangeState(Gamestates.Play);
    }

    public void OnClickExit()
    {
        Gamestate.TryToChangeState(Gamestates.Quit);
    }
}
