using ScriptableObjects.EnemyTank;
using UnityEngine;

namespace EnemyTank
{
    public class EnemyTankModel
    {
        private float speed;
        private float damage;
        private float patrolRadius;
        private float rotationSpeed;
        private AudioClip shootSound;

        public float Speed { get => speed; }
        public float Health { get; set; }
        public float Damage { get => damage; }
        public float PatrolRadius { get => patrolRadius; }

        public float RotationSpeed { get => rotationSpeed; }

        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            speed = enemyTankScriptableObject.Speed;
            Health = enemyTankScriptableObject.Health;
            damage = enemyTankScriptableObject.Damage;
            patrolRadius = enemyTankScriptableObject.PatrolRadius;
            rotationSpeed = enemyTankScriptableObject.RotationSpeed;
            shootSound = enemyTankScriptableObject.ShootSound;
        }
    }
}
