using Bullet;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerTank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BulletSpawner bulletSpawner;

        public Rigidbody Rb
        {
            get => rb;
        }

        public BulletSpawner BulletSpawner
        {
            get => bulletSpawner;
        }

        private void FixedUpdate()
        {
            tankController.Rotate();
            tankController.Move();
        }

        public void InputHandler(InputAction.CallbackContext context)
        {
            tankController.InputHandler(context);
        }

        public void SetTankController(TankController controller)
        {
            tankController = controller;
        }
    }
}

