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
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Transform turretTransform;

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

        public AudioSource AudioSource
        {
            get => audioSource;
        }

        public Transform TurretTransform
        {
            get => turretTransform;
        }

        private void Start()
        {
            healthValue.Initialize(tankController.GetHealth());
            audioSource.clip = tankController.GetDriveSound();
        }

        private void FixedUpdate()
        {
            tankController.Look();
            tankController.Move();
        }

        private void LateUpdate()
        {
            healthValue.UpdateValue(tankController.GetHealth());
            achievementSystem.transform.rotation = Quaternion.Euler(0, 200, 0);
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

        public void ApplyForce(Vector3 force)
        {
            tankController.ApplyForce(force);
        }

        public void CrashDamage()
        {
            NotifyObservers(AchievementType.Crashes);
            tankController.TakeDamage(10);
        }

        public void TakeDamage(float damage)
        {
            NotifyObservers(AchievementType.BulletsHit);
            tankController.TakeDamage(damage);
        }
    }
}

