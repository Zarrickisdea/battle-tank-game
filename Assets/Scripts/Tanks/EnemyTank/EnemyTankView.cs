using UnityEngine;
using UnityEngine.AI;

namespace EnemyTank
{   
    public class EnemyTankView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        private EnemyTankController enemyTankController;

        public NavMeshAgent NavMeshAgent
        {
            get => navMeshAgent;
        }

        private void Update()
        {
            enemyTankController.StartPatrol();
        }

        public void SetController(EnemyTankController controller)
        {
            enemyTankController = controller;
        }

        public void TakeDamage(float damage)
        {
            enemyTankController.TakeDamage(damage);
        }
    }
}