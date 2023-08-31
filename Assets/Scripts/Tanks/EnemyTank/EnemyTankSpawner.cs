using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyTank
{
    public class EnemyTankSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyTankPrefab;
        [SerializeField] private NavMeshSurface navMeshSurface;

        private void Start()
        {
            if (navMeshSurface.navMeshData != null)
            {
                for (int i = 0; i < 30; i++)
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
                Instantiate(enemyTankPrefab, navMeshHit.position, Quaternion.identity);
                print("enemy spawned");
            }
            else
            {
                print("AWW HELL NAH CUH");
            }
        }

        private Vector3 GenerateRandomSpawnPosition()
        {
            Vector3 spawnPosition = Vector3.zero + Random.insideUnitSphere * 25;
            return spawnPosition;
        }
    }
}