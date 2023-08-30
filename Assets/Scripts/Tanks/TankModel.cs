using UnityEngine;

public class TankModel
{
    private float speed;
    private float health;

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        speed = tankScriptableObject.moveSpeed;
        health = tankScriptableObject.health;
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

