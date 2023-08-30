using UnityEngine;
using PlayerTank;

namespace ScriptableObjects.Tanks
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/TankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        [SerializeField] private TankType tankType;
        [SerializeField] private TankView tankView;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float health;

        public TankType TankType => tankType;
        public TankView TankView => tankView;
        public float MoveSpeed => moveSpeed;
        public float Health => health;

    }
}
