using ScriptableObjects.Tanks;

namespace PlayerTank
{
    public class TankModel
    {
        private float speed;
        private float health;
        private float fireCooldown;

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            speed = tankScriptableObject.MoveSpeed;
            health = tankScriptableObject.Health;
            fireCooldown = tankScriptableObject.FireCooldown;
        }

        public float Speed
        {
            get => speed;
        }

        public float Health
        {
            get => health;
        }

        public float FireCooldown
        {
            get => fireCooldown;
        }
    }
}

