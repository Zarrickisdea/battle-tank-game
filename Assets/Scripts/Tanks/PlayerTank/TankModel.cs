using ScriptableObjects.Tanks;
using UnityEngine;

namespace PlayerTank
{
    public class TankModel
    {
        private float speed;
        private float fireCooldown;
        private float damage;
        private AudioClip shootSound;
        public float Health { get; set; }

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            speed = tankScriptableObject.MoveSpeed;
            Health = tankScriptableObject.Health;
            fireCooldown = tankScriptableObject.FireCooldown;
            damage = tankScriptableObject.Damage;
            shootSound = tankScriptableObject.ShootSound;
        }

        public float Speed
        {
            get => speed;
        }

        public float FireCooldown
        {
            get => fireCooldown;
        }
        public float Damage
        {
            get => damage;
        }
    }
}

