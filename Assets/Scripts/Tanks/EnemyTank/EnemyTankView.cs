using UnityEngine;
using UnityEngine.AI;

namespace EnemyTank
{   
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Transform turretTransform;
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private Transform healthBar;
        [SerializeField] private FillValueNumber healthValue;

        private EnemyTankController enemyTankController;
        public EnemyTankController EnemyTankController
        {
            get => enemyTankController;
        }

        public NavMeshAgent NavMeshAgent
        {
            get => navMeshAgent;
        }

        public BulletSpawner BulletSpawner
        {
            get => bulletSpawner;
        }

        public Transform HealthBar
        {
            get => healthBar;
        }

        public FillValueNumber HealthValue
        {
            get => healthValue;
        }

        public Transform TurretTransform
        {
            get => turretTransform;
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
            healthValue.Initialize(enemyTankController.GetHealth());
        }

        private void Update()
        {
            StateMachine.currentState.UpdateLogic();
        }

        private void FixedUpdate()
        {
            StateMachine.currentState.UpdatePhysics();
        }

        private void LateUpdate()
        {
            StateMachine.currentState.UpdateUI();
        }

        private void OnCollisionEnter(Collision collision)
        {
            StateMachine.currentState.ResolveCollision(collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            StateMachine.currentState.ResolveTriggers(other);
        }

        public void SetController(EnemyTankController controller)
        {
            enemyTankController = controller;
        }

        public void Fire()
        {
            enemyTankController.Fire();
        }

        public void TakeDamage(float damage)
        {
            enemyTankController.TakeDamage(damage);
        }
    }
}