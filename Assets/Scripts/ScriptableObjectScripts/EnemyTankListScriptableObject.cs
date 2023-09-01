using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.EnemyTank
{
    [CreateAssetMenu(fileName = "EnemyTankList", menuName = "ScriptableObjects/EnemyTankList")]
    public class EnemyTankListScriptableObject : ScriptableObject
    {
        [SerializeField] private List<EnemyTankScriptableObject> enemyTankList;

        public EnemyTankScriptableObject this[int index]
        {
            get
            {
                return enemyTankList[index];
            }
        }

        public int Count
        {
            get
            {
                return enemyTankList.Count;
            }
        }
    }
}
