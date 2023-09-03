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

        public void SetController(EnemyTankController controller)
        {
            enemyTankController = controller;
        }

        public void Update()
        {
            enemyTankController.StartPatrol();
        }
    }
}