using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTank : GenericSingleton<PlayerTank>
{
    [SerializeField] private float speed;
    private Vector2 movementVector;
    public void InputHandler(InputAction.CallbackContext context)
    {
        if (context.action.name == "Move")
        {
            movementVector = context.ReadValue<Vector2>();
        }
    }

    private void Update()
    {
        transform.position += new Vector3(-movementVector.x, 0, -movementVector.y) * speed * Time.deltaTime;
        if (movementVector != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-movementVector.x, 0, -movementVector.y));
        }
    }
}
