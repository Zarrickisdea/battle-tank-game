using UnityEngine;
using ScriptableObjects.EnemyTank;

namespace EnemyTank
{
    public class EnemyTankModel
    {
        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] private float damage;

        public float Speed { get => speed; }
        public float Health { get => health; }
        public float Damage { get => damage; }

        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            speed = enemyTankScriptableObject.Speed;
            health = enemyTankScriptableObject.Health;
            damage = enemyTankScriptableObject.Damage;
        }
    }
}
