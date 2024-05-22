using Isekai.Utility;
using System.Collections.Generic;

public class EnemyList : Singleton<EnemyList>
{
    List<Enemy> _enemies;

    public static List<Enemy> Enemies => _Instance._enemies;

    public static void AddEnemy(Enemy newEnemy)
    {
        if (Enemies.Contains(newEnemy)) return;
        _Instance._enemies.Add(newEnemy);
    }

    public static void RemoveEnemy(Enemy newEnemy)
    {
        if(Enemies.Contains(newEnemy))
        {
            _Instance._enemies.Remove(newEnemy);
        }
    }
}
