using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private BombSpawner _bombSpawner;

    public void TakeBomb()
    {
        _bombSpawner.Spawn();
    }
}