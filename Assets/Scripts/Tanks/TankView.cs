using UnityEngine;
using UnityEngine.InputSystem;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    private void Update()
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

