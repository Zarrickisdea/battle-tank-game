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
            tankController.Look();
            tankController.Move();
        }

        private void InputHandler(InputAction.CallbackContext context)
        {
            tankController.InputHandler(context);
        }

        public void SetTankController(TankController controller)
        {
            tankController = controller;
        }
    }
}

