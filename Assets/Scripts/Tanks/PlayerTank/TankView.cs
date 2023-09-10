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
        [SerializeField] private Transform healthBar;
        [SerializeField] private FillValueNumber healthValue;

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

        private void Start()
        {
            healthValue.Initialize(tankController.GetHealth());
        }

        private void FixedUpdate()
        {
            tankController.Look();
            tankController.Move();
        }

        private void LateUpdate()
        {
            healthValue.UpdateValue(tankController.GetHealth());
            achievementSystem.transform.rotation = Quaternion.Euler(0, 220, 0);
            healthBar.rotation = Quaternion.Euler(0, 220, 0);
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
            tankController.TakeDamage(10);
        }

        public void TakeDamage(float damage)
        {
            tankController.TakeDamage(damage);
        }
    }
}

