using Isekai.Utility;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private GameObject _player;

    public static void SetPlayer(GameObject newPlayer)
    {
        _Instance._player = newPlayer;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }
}
