using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerTank
{
    public class TankView : ObserverSubject, IDamageable
    {
        private TankController tankController;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private AchievementSystem achievementSystem;

        public Rigidbody Rb
        {
            get => rb;
        }

        public BulletSpawner BulletSpawner
        {
            get => bulletSpawner;
        }

        public AchievementSystem AchievementSystem
        {
            get => achievementSystem;
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

        public void CrashDamage()
        {
            NotifyObservers();
            tankController.CrashDamage();
        }

        public void TakeDamage(float damage)
        {
            tankController.TakeDamage(damage);
        }
    }
}

