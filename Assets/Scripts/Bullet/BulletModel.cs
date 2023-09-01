using ScriptableObjects.Bullets;
using UnityEngine;

namespace Bullet
{
    public class BulletModel
    {
        private float speed;
        private float damage;
        private float lifeTime;
        private GameObject explosion;
        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            speed = bulletScriptableObject.Speed;
            damage = bulletScriptableObject.Damage;
            lifeTime = bulletScriptableObject.LifeTime;
            explosion = bulletScriptableObject.Explosion;
        }

        public float Speed => speed;
        public float Damage => damage;
        public float LifeTime => lifeTime;
        public GameObject Explosion => explosion;

    }
}
