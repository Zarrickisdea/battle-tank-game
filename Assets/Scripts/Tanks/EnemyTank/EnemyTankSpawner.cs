using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using ScriptableObjects.EnemyTank;
using EnemyTank;
using System.Collections.Generic;

public class EnemyTankSpawner : MonoBehaviour
{
    [SerializeField] private EnemyTankListScriptableObject enemyTankList;
    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private float radius = 10f;

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
            LevelManager.Instance.AddEnemyTank(enemyTankController?.EnemyTankView);
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero + Random.insideUnitSphere * radius;
        return spawnPosition;
    }
}