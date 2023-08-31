using ScriptableObjects.Bullets;

namespace Bullet
{
    public class BulletModel
    {
        private float speed;
        private float damage;
        private float lifeTime;
        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            speed = bulletScriptableObject.Speed;
            damage = bulletScriptableObject.Damage;
            lifeTime = bulletScriptableObject.LifeTime;
        }

        public float Speed => speed;
        public float Damage => damage;
        public float LifeTime => lifeTime;

    }
}
