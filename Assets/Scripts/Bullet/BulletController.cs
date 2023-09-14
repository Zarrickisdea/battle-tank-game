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

        public BulletController(BulletView view, BulletModel model, Transform spawnPoint)
        {
            bulletModel = model;
            bulletView = GameObject.Instantiate<BulletView>(view, spawnPoint.position, spawnPoint.rotation);
            bulletView.SetBulletController(this);
        }

        public void Fire()
        {
            Vector3 forceDirection = bulletSpawner.transform.forward * bulletModel.Speed;
            bulletView.Rb.velocity = forceDirection;
            bulletView.AudioSource.PlayOneShot(bulletModel.ShootSound);
        }


        public BulletModel GetBulletModel()
        {
            return bulletModel;
        }

        public void DestroyBullet()
        {
            bulletView.Explode();
            SetPosition(Vector3.zero);
            SetRotation(Quaternion.identity);
            Deactivate();
            ReturnBulletToPool();
        }

        public void Deactivate()
        {
            bulletView.gameObject.SetActive(false);
        }

        public void Activate(Transform spawnPoint)
        {
            bulletView.gameObject.SetActive(true);
            bulletView.transform.position = spawnPoint.position;
            bulletView.transform.rotation = spawnPoint.rotation;
            Fire();
        }

        public void ReturnBulletToPool()
        {
            bulletSpawner.ReturnBulletToPool(this);
        }

        public void SetDamage(float damage)
        {
            bulletModel.Damage = damage;
        }

        public void SetBulletSpawner(BulletSpawner bulletSpawner)
        {
            this.bulletSpawner = bulletSpawner;
        }

        public void SetPosition(Vector3 position)
        {
            bulletView.transform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            bulletView.transform.rotation = rotation;
        }
    }
}
