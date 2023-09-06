using UnityEngine;
using UnityEngine.AI;

namespace EnemyTank
{   
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        private EnemyTankController enemyTankController;

        public NavMeshAgent NavMeshAgent
        {
            get => navMeshAgent;
        }

        #region StateMachine
        public StateMachine StateMachine { get; private set; }
        public EnemyIdleState EnemyIdleState { get; private set; }
        public EnemyChaseState EnemyChaseState { get; private set; }
        public EnemyAttackState EnemyAttackState { get; private set; }
        public EnemyPatrolState EnemyPatrolState { get; private set; }
        #endregion

        private void Awake()
        {
            StateMachine = new StateMachine();
            EnemyIdleState = new EnemyIdleState(this, StateMachine);
            EnemyChaseState = new EnemyChaseState(this, StateMachine);
            EnemyAttackState = new EnemyAttackState(this, StateMachine);
            EnemyPatrolState = new EnemyPatrolState(this, StateMachine);
        }

        private void Start()
        {
            StateMachine.Initialize(EnemyIdleState);
        }

        private void Update()
        {
            StateMachine.currentState.UpdateLogic();
        }

        private void FixedUpdate()
        {
            StateMachine.currentState.UpdatePhysics();
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