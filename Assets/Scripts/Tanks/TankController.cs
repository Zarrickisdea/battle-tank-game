using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class TankController
{
    private TankView tankView { get; set; }
    private TankModel tankModel { get; set; }

    private Vector2 moveVector;

    public TankController(TankView view, TankModel model, CinemachineVirtualCamera camera)
    {
        tankModel = model;
        tankView = GameObject.Instantiate<TankView>(view);
        camera = GameObject.Instantiate<CinemachineVirtualCamera>(camera);
        tankView.SetTankController(this);
        tankView.SetCamera(camera);
    }

    public void InputHandler(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void Move()
    {
        tankView.transform.position += new Vector3(-moveVector.x, 0, -moveVector.y) * tankModel.Speed * Time.deltaTime;
    }

    public void Rotate()
    {
        if (moveVector != Vector2.zero)
        {
            tankView.transform.rotation = Quaternion.LookRotation(new Vector3(-moveVector.x, 0, -moveVector.y));
        }
    }
}
