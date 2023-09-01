using UnityEngine;
using PlayerTank;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        [SerializeField] private Rigidbody rb;
        private float bulletLife;

        public Rigidbody Rb
        {
            get => rb;
        }

        private void Start()
        {
            bulletLife = bulletController.GetBulletModel().LifeTime;
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
            if (collision.gameObject.GetComponent<TankView>() == null)
            {
                bulletController.DestroyBullet();
            }
        }

        public void Explode()
        {
            GameObject explosion = Instantiate(bulletController.GetBulletModel().Explosion, transform.position, transform.rotation);
            explosion.GetComponent<ParticleSystem>().Play();
            Destroy(explosion, 1f);
            Destroy(gameObject);

        }

        public void SetBulletController(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }
    }
}
