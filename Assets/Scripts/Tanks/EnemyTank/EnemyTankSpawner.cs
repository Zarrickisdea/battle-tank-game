using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using ScriptableObjects.EnemyTank;
using EnemyTank;
using System.Collections.Generic;

public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
{
    [SerializeField] private EnemyTankListScriptableObject enemyTankList;
    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private float radius = 10f;
    private List<EnemyTankView> enemyList = new List<EnemyTankView>();
    public int EnemyCount 
    { 
        get => enemyList.Count;
    }

    private void Start()
    {
        if (navMeshSurface.navMeshData != null)
        {
            for (int i = 0; i < radius; i++)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GenerateRandomSpawnPosition();

        NavMeshHit navMeshHit;

        if (NavMesh.SamplePosition(spawnPosition, out navMeshHit, 5f, NavMesh.AllAreas))
        {
            EnemyTankScriptableObject enemyTank = enemyTankList[Random.Range(0, enemyTankList.Count)];
            EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTank);
            EnemyTankController enemyTankController = new EnemyTankController(enemyTank.EnemyTankView, enemyTankModel, navMeshHit.position);
            enemyList.Add(enemyTankController?.EnemyTankView);
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero + Random.insideUnitSphere * radius;
        return spawnPosition;
    }

    public void RemoveFromList(EnemyTankView enemyTankView)
    {
        if (enemyList.Contains(enemyTankView))
        {
            enemyList.Remove(enemyTankView);
        }
        if (enemyList.Count == 0)
        {
            LevelManager.Instance.DestroyLevel();
        }
    }
}