using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankView : MonoBehaviour
{
    private TankController tankController { get; set; }

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

    public void SetCamera(CinemachineVirtualCamera virtualCamera)
    {
        virtualCamera.transform.position = new Vector3(35, 15, 35);
        virtualCamera.Follow = this.transform;
    }
}

