using UnityEngine;
using PlayerTank;
using EnemyTank;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private AudioSource audioSource;

        private BulletController bulletController;
        private float bulletLife;
        private GameObject explosion;

        public Rigidbody Rb
        {
            get => rb;
        }

        public AudioSource AudioSource
        {
            get => audioSource;
        }

        private void Start()
        {
            bulletLife = bulletController.GetBulletModel().LifeTime;
            explosion = bulletController.GetBulletModel().Explosion;
            audioSource.clip = bulletController.GetBulletModel().ShootSound;
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
            EnemyTankView enemyTankView = collision.gameObject.GetComponent<EnemyTankView>();
            TankView tankView = collision.gameObject.GetComponent<TankView>();

            if (enemyTankView != null)
            {
                enemyTankView.TakeDamage(bulletController.GetBulletModel().Damage);
            }
            else if (tankView != null)
            {
                tankView.TakeDamage(bulletController.GetBulletModel().Damage);
            }

            bulletController.DestroyBullet();
        }


        public void Explode()
        {
            GameObject effect = Instantiate(explosion, transform.position, transform.rotation);
            effect.GetComponent<ParticleSystem>().Play();
            Destroy(effect, 1f);
            bulletController.Deactivate();
        }

        public void SetBulletController(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }
    }
}
