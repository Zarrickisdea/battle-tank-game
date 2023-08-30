using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/TankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public TankView tankView;
    public float moveSpeed;
    public float health;
}
