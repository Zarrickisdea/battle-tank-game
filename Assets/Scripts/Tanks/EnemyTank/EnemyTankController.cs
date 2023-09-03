using UnityEngine;
using UnityEngine.AI;

namespace EnemyTank
{
    public class EnemyTankController
    {
        private EnemyTankView enemyTankView;
        private EnemyTankModel enemyTankModel;
        private NavMeshAgent navMeshAgent;

        public EnemyTankController(EnemyTankView view, EnemyTankModel model, Vector3 position)
        {
            enemyTankModel = model;
            enemyTankView = GameObject.Instantiate<EnemyTankView>(view);
            enemyTankView.SetController(this);
            enemyTankView.transform.position = position;
            navMeshAgent = enemyTankView.NavMeshAgent;
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
    }
}
