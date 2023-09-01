using UnityEditor.SceneTemplate;
using UnityEngine;

namespace Bullet
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        public BulletController(BulletView view, BulletModel model, Transform spawnTransform)
        {
            bulletModel = model;
            bulletView = GameObject.Instantiate<BulletView>(view, spawnTransform.position, spawnTransform.rotation);
            bulletView.SetBulletController(this);
            Fire();
        }

        private void Fire()
        {
            bulletView.Rb.AddForce(bulletView.transform.forward * bulletModel.Speed, ForceMode.Impulse);
        }

        public BulletModel GetBulletModel()
        {
            return bulletModel;
        }

        public BulletView GetBulletView()
        {
            return bulletView;
        }

        public void DestroyBullet()
        {
            bulletView.Explode();
        }
    }
}
