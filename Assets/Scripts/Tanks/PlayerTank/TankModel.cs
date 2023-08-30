using ScriptableObjects.Tanks;

namespace PlayerTank
{
    public class TankModel
    {
        private float speed;
        private float health;

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            speed = tankScriptableObject.MoveSpeed;
            health = tankScriptableObject.Health;
        }

        public float Speed
        {
            get => speed;
        }

        public float Health
        {
            get => health;
        }
    }
}

