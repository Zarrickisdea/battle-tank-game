using ScriptableObjects.EnemyTank;

namespace EnemyTank
{
    public class EnemyTankModel
    {
        private float speed;
        private float health;
        private float damage;
        private float patrolRadius;

        public float Speed { get => speed; }
        public float Health 
        { 
            get => health; 
            set => health = value;
        }
        public float Damage { get => damage; }
        public float PatrolRadius { get => patrolRadius; }

        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            speed = enemyTankScriptableObject.Speed;
            health = enemyTankScriptableObject.Health;
            damage = enemyTankScriptableObject.Damage;
            patrolRadius = enemyTankScriptableObject.PatrolRadius;
        }
    }
}
