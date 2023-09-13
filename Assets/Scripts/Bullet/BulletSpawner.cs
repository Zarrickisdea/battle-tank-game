using UnityEngine;
using Bullet;
using ScriptableObjects.Bullets;
using System.Collections.Generic;
using PlayerTank;

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
            BulletController bulletController = GenerateBullet();
            bulletPool.Enqueue(bulletController);
        }
    }

    private BulletController GenerateBullet()
    {
        BulletModel bulletModel = new BulletModel(bullet);
        BulletController bulletController = new BulletController(bullet.BulletView, bulletModel);
        bulletController.SetBulletSpawner(this);
        bulletController.GetBulletView().gameObject.SetActive(false);
        return bulletController;
    }

    public void FireBullet(Transform spawner, float damage)
    {
        BulletController bulletController = GetBulletFromPool();
        bulletController.SetDamage(damage);
        bulletController.GetBulletView().transform.position = spawner.position;
        bulletController.GetBulletView().transform.rotation = spawner.rotation;
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
            BulletController newbulletController = GenerateBullet();
            return newbulletController;
        }
    }
}