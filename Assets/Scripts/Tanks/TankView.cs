using UnityEngine;
using UnityEngine.InputSystem;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    [SerializeField] private Rigidbody rb;

    public Rigidbody Rb
    {
        get => rb;
    }

    private void FixedUpdate()
    {
        tankController.Rotate();
        tankController.Move();
    }
    public void InputHandler(InputAction.CallbackContext context)
    {
        tankController.InputHandler(context);
    }

    public void SetTankController(TankController controller)
    {
        tankController = controller;
    }
}

