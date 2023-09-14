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
        [SerializeField] private float lifeTime;
        [SerializeField] private GameObject explosion;
        [SerializeField] private AudioClip shootSound;

        public BulletView BulletView => bulletView;
        public float Speed => speed;
        public float LifeTime => lifeTime;
        public GameObject Explosion => explosion;
        public AudioClip ShootSound => shootSound;
    }
}
