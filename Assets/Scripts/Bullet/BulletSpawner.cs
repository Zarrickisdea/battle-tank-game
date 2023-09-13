using UnityEngine;
using Bullet;
using ScriptableObjects.Bullets;
using System.Collections.Generic;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletScriptableObject bullet;
    [SerializeField] private int poolSize;

    private Queue<BulletController> bulletPool = new Queue<BulletController>();

    private void Start()
    {
        InitializeBulletPool();
    }

    private void InitializeBulletPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.BulletView, bulletModel);
            bulletController.SetBulletSpawner(this);
            bulletController.Deactivate();
            bulletPool.Enqueue(bulletController);
        }
    }

    public void FireBullet(Transform transform, float damage)
    {
        BulletController bulletController = GetBulletFromPool();
        bulletController.GetBulletView().transform.position = transform.position;
        bulletController.GetBulletView().transform.rotation = transform.rotation;
        bulletController.SetDamage(damage);
        bulletController.GetBulletView().gameObject.SetActive(true);
        bulletController.Fire();
    }

    private BulletController GetBulletFromPool()
    {
        if (bulletPool.Count > 0)
        {
            return bulletPool.Dequeue();
        }
        else
        {
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController newBulletController = new BulletController(bullet.BulletView, bulletModel);
            return newBulletController;
        }
    }

    public void AddBackToPool(BulletController bulletController)
    {
        bulletPool.Enqueue(bulletController);
    }
}