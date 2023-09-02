using UnityEngine;

namespace EnemyTank
{   
    public class EnemyTankView : MonoBehaviour
    {
        private EnemyTankController enemyTankController;

        public void SetController(EnemyTankController controller)
        {
            enemyTankController = controller;
        }

        public void Update()
        {
            if (enemyTankController != null)
            {
                enemyTankController.StartPatrol();
            }
        }
    }
}