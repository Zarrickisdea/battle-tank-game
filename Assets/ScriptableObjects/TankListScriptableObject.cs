using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankListScriptableObject", menuName = "ScriptableObjects/TankListScriptableObject")]
public class TankListScriptableObject : ScriptableObject
{
    [SerializeField] private List<TankScriptableObject> tankList;

    public TankScriptableObject this[int index]
    {
        get
        {
            return tankList[index];
        }
    }

    public int Count
    {
        get
        {
            return tankList.Count;
        }
    }
}
