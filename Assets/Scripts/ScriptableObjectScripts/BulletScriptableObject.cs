using Bullet;
using UnityEngine;

namespace ScriptableObjects.Bullets
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        [SerializeField] private BulletView bulletView;

        [Header("Bullet Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] private float lifeTime;

        public BulletView BulletView => bulletView;
        public float Speed => speed;
        public float Damage => damage;
        public float LifeTime => lifeTime;
    }
}
