using UnityEngine;

namespace Bullet
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        private BulletSpawner bulletSpawner;

        public BulletView GetBulletView()
        {
            return bulletView;
        }

        public BulletController(BulletView view, BulletModel model)
        {
            bulletModel = model;
            bulletView = GameObject.Instantiate<BulletView>(view);
            bulletView.SetBulletController(this);
        }

        public void Fire()
        {
            bulletView.Rb.AddForce(bulletView.transform.forward * bulletModel.Speed, ForceMode.Impulse);
            bulletView.AudioSource.PlayOneShot(bulletModel.ShootSound);
        }

        public BulletModel GetBulletModel()
        {
            return bulletModel;
        }

        public void DestroyBullet()
        {
            bulletView.Explode();
        }

        public void Deactivate()
        {
            bulletView.gameObject.SetActive(false);
        }

        public void SetDamage(float damage)
        {
            bulletModel.Damage = damage;
        }

        public void SetBulletSpawner(BulletSpawner bulletSpawner)
        {
            this.bulletSpawner = bulletSpawner;
        }
    }
}
