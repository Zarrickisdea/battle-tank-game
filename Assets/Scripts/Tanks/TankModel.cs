using UnityEngine;

public class TankModel
{
    private float speed;
    private Rigidbody rb;
    public Rigidbody Rb
    {
        get => rb;
        set => rb = value;
    }

    public TankModel(float speed)
    {
        this.speed = speed;
    }

    public float Speed
    {
        get => speed;
    }
}

