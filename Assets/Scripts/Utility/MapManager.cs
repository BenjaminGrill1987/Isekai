using UnityEngine;
using UnityEngine.SceneManagement;

namespace Isekai.Utility
{

    public class MapManager : Singleton<MapManager>
    {
        [SerializeField] private Vector2 _playerPos;

        public static void MapChange(string newMap, Vector2 mapPos)
        {
            SceneManager.LoadScene(newMap);
            _Instance._playerPos = mapPos;
        }

        public static void GameQuit() => Application.Quit();

        public static Vector2 SetPlayerPos() => _Instance._playerPos;

    }
}