using UnityEngine;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        [SerializeField] private Rigidbody rb;

        public Rigidbody Rb
        {
            get => rb;
        }

        public void SetBulletController(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }
    }
}
