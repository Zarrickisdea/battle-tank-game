using ScriptableObjects.Bullets;
using UnityEngine;

namespace Bullet
{
    public class BulletModel
    {
        private float speed;
        private float lifeTime;
        private GameObject explosion;
        private float damage;
        public BulletModel(BulletScriptableObject bulletScriptableObject, float damage)
        {
            speed = bulletScriptableObject.Speed;
            lifeTime = bulletScriptableObject.LifeTime;
            explosion = bulletScriptableObject.Explosion;
            this.damage = damage;
        }

        public float Speed => speed;
        public float LifeTime => lifeTime;
        public GameObject Explosion => explosion;
        public float Damage => damage;

    }
}
