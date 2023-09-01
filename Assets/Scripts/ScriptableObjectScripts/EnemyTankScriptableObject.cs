using UnityEngine;
using EnemyTank;

namespace ScriptableObjects.EnemyTank
{
    [CreateAssetMenu(fileName = "Enemy Tank", menuName = "ScriptableObjects/EnemyTank")]
    public class EnemyTankScriptableObject : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] private float damage;
        [SerializeField] private EnemyTankView enemyTankView;

        public float Speed { get => speed; }
        public float Health { get => health; }
        public float Damage { get => damage; }
        public EnemyTankView EnemyTankView { get => enemyTankView; }
    }
}
