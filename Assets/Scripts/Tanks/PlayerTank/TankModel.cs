using ScriptableObjects.Tanks;
using UnityEngine;

namespace PlayerTank
{
    public class TankModel
    {
        private float speed;
        private float fireCooldown;
        private float damage;
        private AudioClip driveSound;
        public float Health { get; set; }

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            speed = tankScriptableObject.MoveSpeed;
            Health = tankScriptableObject.Health;
            fireCooldown = tankScriptableObject.FireCooldown;
            damage = tankScriptableObject.Damage;
            driveSound = tankScriptableObject.DriveSound;
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

        public AudioClip DriveSound
        {
            get => driveSound;
        }
    }
}

