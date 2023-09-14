using UnityEngine;
using Bullet;
using ScriptableObjects.Bullets;
using System.Collections.Generic;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletScriptableObject bullet;
    [SerializeField] private int poolSize;

    private Queue<BulletController> bulletPool = new Queue<BulletController>();

    private void Awake()
    {
        InitializeBulletPool();
    }

    private void InitializeBulletPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            BulletController bulletController = GenerateBullet();
            bulletPool.Enqueue(bulletController);
        }
    }

    private BulletController GenerateBullet()
    {
        BulletModel bulletModel = new BulletModel(bullet);
        BulletController bulletController = new BulletController(bullet.BulletView, bulletModel, transform);
        bulletController.SetBulletSpawner(this);
        bulletController.Deactivate();
        return bulletController;
    }

    private BulletController GetBulletFromPool()
    {
        if (bulletPool.Count > 0)
        {
            return bulletPool.Dequeue();
        }
        else
        {
            return GenerateBullet();
        }
    }

    public void ReturnBulletToPool(BulletController bulletController)
    {
        bulletPool.Enqueue(bulletController);
    }

    public void FireBullet(float damage)
    {
        BulletController bulletController = GetBulletFromPool();
        bulletController.SetDamage(damage);
        bulletController.Activate(transform);
    }
}