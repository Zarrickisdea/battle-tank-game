using UnityEngine;
using PlayerTank;
using EnemyTank;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;

        private BulletController bulletController;
        private float bulletLife;
        private GameObject explosion;

        public Rigidbody Rb
        {
            get => rb;
        }

        private void Start()
        {
            bulletLife = bulletController.GetBulletModel().LifeTime;
            explosion = bulletController.GetBulletModel().Explosion;
        }

        private void Update()
        {
            bulletLife -= Time.deltaTime;

            if (bulletLife <= 0)
            {
                bulletController.DestroyBullet();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyTankView>() != null)
            {
                collision.gameObject.GetComponent<EnemyTankView>().TakeDamage(bulletController.GetBulletModel().Damage);
            }
            bulletController.DestroyBullet();
        }

        public void Explode()
        {
            GameObject effect = Instantiate(explosion, transform.position, transform.rotation);
            effect.GetComponent<ParticleSystem>().Play();
            Destroy(effect, 1f);
            Destroy(gameObject);
        }

        public void SetBulletController(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }
    }
}
