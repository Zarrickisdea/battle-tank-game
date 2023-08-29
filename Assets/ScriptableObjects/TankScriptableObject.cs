using UnityEngine;

public class TankScriptableObject : ScriptableObject
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/TankScriptableObject", order = 1)]
    public TankType tankType;

}
