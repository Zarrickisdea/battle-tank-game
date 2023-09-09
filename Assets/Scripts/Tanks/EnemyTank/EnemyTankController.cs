using Bullet;
using PlayerTank;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyTank
{
    public class EnemyTankController
    {
        private EnemyTankView enemyTankView;
        private EnemyTankModel enemyTankModel;
        private NavMeshAgent navMeshAgent;
        public EnemyTankView EnemyTankView { get => enemyTankView; }

        public EnemyTankController(EnemyTankView view, EnemyTankModel model, Vector3 position)
        {
            enemyTankModel = model;
            enemyTankView = GameObject.Instantiate<EnemyTankView>(view);
            enemyTankView.SetController(this);
            enemyTankView.transform.position = position;

            navMeshAgent = enemyTankView.NavMeshAgent;
            navMeshAgent.speed = enemyTankModel.Speed;
        }

        public void StartPatrol()
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                Vector3 randomPoint = Random.insideUnitSphere * enemyTankModel.PatrolRadius;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, enemyTankModel.PatrolRadius, NavMesh.AllAreas))
                {
                    navMeshAgent.SetDestination(hit.position);
                }
            }
        }

        public void StartChase(Transform target)
        {
            navMeshAgent.SetDestination(target.position);
        }

        public void RotateTurret(Vector3 position)
        {
            Vector3 direction = (position - enemyTankView.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            enemyTankView.transform.rotation = Quaternion.Slerp(enemyTankView.transform.rotation, lookRotation, Time.deltaTime * enemyTankModel.RotationSpeed);
        }

        public void Fire()
        {
            BulletSpawner bulletSpawner = enemyTankView.BulletSpawner;
            BulletController bullet = bulletSpawner.SpawnBullet(bulletSpawner.transform, enemyTankModel.Damage);
        }

        public void TakeDamage(float damage)
        {
            enemyTankModel.Health -= damage;
            if (enemyTankModel.Health <= 0)
            {
                EnemyTankSpawner.Instance.RemoveFromList(enemyTankView);
                GameObject.Destroy(enemyTankView.gameObject);
            }
        }
    }
}
