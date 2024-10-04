using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private Transform _spawnPoint;
    
    public void Spawn()
    {
        Instantiate(_bombPrefab, _spawnPoint.position, Quaternion.identity);
    }
}
