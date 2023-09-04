using UnityEngine;
using Bullet;
using ScriptableObjects.Bullets;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletScriptableObject bullet;

    public BulletController SpawnBullet(Transform spawnTransform, float damage)
    {
        BulletModel bulletModel = new BulletModel(bullet, damage);
        BulletController bulletController = new BulletController(bullet.BulletView, bulletModel, spawnTransform);
        return bulletController;
    }
}
