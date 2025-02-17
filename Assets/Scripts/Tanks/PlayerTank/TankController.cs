using UnityEngine;
using UnityEngine.InputSystem;
using Bullet;

namespace PlayerTank
{
    public class TankController
    {
        private TankView tankView;
        private TankModel tankModel;

        public TankView GetTankView()
        {
            return tankView;
        }

        private bool moveVector;
        private Vector2 lookVector;
        private Vector3 currentVelocity;
        private bool canFire = true;

        public TankController(TankView view, TankModel model)
        {
            tankModel = model;
            tankView = GameObject.Instantiate<TankView>(view);
            tankView.SetTankController(this);
            tankView.AchievementSystem.Initialize();
        }

        public void InputHandler(InputAction.CallbackContext context)
        {
            if (context.action.name == "Move")
            {
                moveVector = context.ReadValue<float>() > 0.5;
            }
            else if (context.action.name == "Fire" && canFire)
            {
                Fire();
                tankView.NotifyObservers(AchievementType.BulletsFired);
            }
            else if (context.action.name == "Look")
            {
                lookVector = context.ReadValue<Vector2>();
            }
        }

        public void Look()
        {
            if (lookVector != Vector2.zero)
            {
                Vector3 lookDirection = new Vector3(-lookVector.x, 0, -lookVector.y);
                tankView.transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }

        public void Move()
        {
            Vector3 moveDirection = Quaternion.Euler(0, tankView.Rb.transform.rotation.eulerAngles.y, 0) * new Vector3(0, 0, 1);
            if (moveVector)
            {
                tankView.Rb.velocity = Vector3.Lerp(tankView.Rb.velocity, moveDirection * tankModel.Speed, tankModel.Speed * Time.deltaTime);
                currentVelocity = tankView.Rb.velocity;
                if (!tankView.AudioSource.isPlaying)
                {
                    tankView.AudioSource.Play();
                }
            }
            else
            {
                tankView.Rb.velocity = Vector3.Lerp(tankView.Rb.velocity, Vector3.zero, tankModel.Speed * Time.deltaTime);
                currentVelocity = tankView.Rb.velocity;
                if (tankView.AudioSource.isPlaying)
                {
                    tankView.AudioSource.Stop();
                }
            }
        }

        public void Fire()
        {
            BulletSpawner bulletSpawner = tankView.BulletSpawner;
            bulletSpawner.FireBullet(tankModel.Damage);

            canFire = false;
            tankView.StartCoroutine(FireCooldown());
        }

        private System.Collections.IEnumerator FireCooldown()
        {
            yield return new WaitForSeconds(tankModel.FireCooldown);
            canFire = true;
        }

        public void TakeDamage(float damage)
        {
            tankModel.Health -= damage;
            if (tankModel.Health <= 0)
            {
                GameObject.Destroy(tankView.gameObject);
                LevelManager.Instance.RemovePlayerTank();
            }
        }

        public void ApplyForce(Vector3 force)
        {
            tankView.Rb.AddForce(force, ForceMode.Impulse);
        }

        public float GetHealth()
        {
            return tankModel.Health;
        }

        public Transform GetTankViewTransform()
        {
            return tankView.transform;
        }

        public AudioClip GetDriveSound()
        {
            return tankModel.DriveSound;
        }
    }
}
