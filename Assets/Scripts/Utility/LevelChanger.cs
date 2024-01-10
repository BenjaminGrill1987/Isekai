using UnityEngine;

namespace Isekai.Utility
{

    public class LevelChanger : MonoBehaviour
    {
        [SerializeField] private string _levelName;
        [SerializeField] private Vector2 _Levelposition;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                MapManager.MapChange(_levelName, _Levelposition);
            }
        }

    }
}