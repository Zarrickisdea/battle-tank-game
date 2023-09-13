using ScriptableObjects.Bullets;
using UnityEngine;

namespace Bullet
{
    public class BulletModel
    {
        private float speed;
        private float lifeTime;
        private GameObject explosion;
        private AudioClip shootSound;
        public float Damage { get; set; }
        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            speed = bulletScriptableObject.Speed;
            lifeTime = bulletScriptableObject.LifeTime;
            explosion = bulletScriptableObject.Explosion;
            shootSound = bulletScriptableObject.ShootSound;
        }

        public float Speed => speed;
        public float LifeTime => lifeTime;
        public GameObject Explosion => explosion;
        public AudioClip ShootSound => shootSound;
    }
}
